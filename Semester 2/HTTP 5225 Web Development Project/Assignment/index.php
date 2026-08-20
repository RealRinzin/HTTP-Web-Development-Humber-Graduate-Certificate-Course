<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Survival Jobs Board</title>
    <link rel="stylesheet" href="./assets/style.css">
</head>

<body>

<?php
// ============================================================
// Include database connection
// ============================================================
require_once "./db_connect.php";
// $sql = "SELECT
//             id,
//             job_title,
//             category,
//             hourly_rate,
//             is_remote,
//             skill_level,
//             date_posted,
//             description
//         FROM jobs
//         WHERE 1=1";

$sql = " SELECT * from jobs INNER JOIN company ON jobs.company_id = company.id";

$sql .= " ORDER BY date_posted DESC";

$result = mysqli_query($conn, $sql);

// Count rows returned
$job_count = mysqli_num_rows($result);

// 
$cat_result  = mysqli_query($conn, "SELECT DISTINCT category FROM jobs ORDER BY category ASC");
$categories  = [];

// Loop through category results and store in array
while ($cat_row = mysqli_fetch_assoc($cat_result)) {
    $categories[] = $cat_row['category'];
}
?>

    <!-- ── Header ──-->
    <header>
        <h1>Toronto Survival Jobs </h1>
        <p>Browse gig and part-time jobs to keep things going between your big break.</p>
    </header>
<!-- Main Section -->
    <main>
        <p class="results-count">
            Showing <strong><?php echo $job_count; ?></strong> job<?php echo ($job_count !== 1) ? 's' : ''; ?>
            <!-- <?php if ($filter_category || $filter_remote !== '' || $filter_skill): ?>
            <?php endif; ?> -->
        </p>

        <?php if ($job_count > 0): ?>

            <div class="jobs-grid">
                <?php
                // ──content loop───────────────
                while ($job = mysqli_fetch_assoc($result)):

                    // Format date 
                    $formatted_date = date("F j, Y", strtotime($job['date_posted']));
                    // Determine remote badge label and class
                    $remote_label = ($job['is_remote'] == 1) ? 'Remote' : 'On-Site';
                    $remote_class = ($job['is_remote'] == 1) ? 'badge-remote' : 'badge-onsite';

                    // Determine skill badge class
                    $skill_class  = ($job['skill_level'] === 'Beginner') ? 'badge-beginner' : 'badge-intermediate';
                ?>

                <div class="job-card" data-category="<?php echo htmlspecialchars($job['category']); ?>">
                    <h2><?php echo htmlspecialchars($job['job_title']); ?></h2>
                    <h4><?php echo htmlspecialchars($job['company_name']); ?></h4>

                    <div class="job-meta">
                        <span class="badge badge-category"><?php echo htmlspecialchars($job['category']); ?></span>
                        <span class="badge <?php echo $remote_class; ?>"><?php echo $remote_label; ?></span>
                        <span class="badge <?php echo $skill_class;  ?>"><?php echo htmlspecialchars($job['skill_level']); ?></span>
                    </div>

                    <div class="job-rate">
                        $<?php echo number_format($job['hourly_rate'], 2); ?>
                        <span>/ hour</span>
                    </div>

                    <p class="job-description"><?php echo htmlspecialchars($job['description']); ?></p>

                    <p class="job-date">Posted: <?php echo $formatted_date; ?></p>

                </div><!-- /.job-card -->

                <?php endwhile; ?>
            </div><!-- /.jobs-grid -->

        <?php else: ?>
            <div class="no-results">
                <p> No jobs found matching your filters. <a href="index.php">Reset filters</a>.</p>
            </div>
        <?php endif; ?>

    </main>

    <footer>
        
    </footer>

<?php
// Close connection
mysqli_close($conn);
?>

</body>
</html>
