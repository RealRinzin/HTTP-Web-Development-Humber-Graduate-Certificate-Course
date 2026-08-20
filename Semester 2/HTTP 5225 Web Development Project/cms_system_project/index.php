<?php 
$pageTitle = "The Dawn & Dust Post | Update with World News";
include "common/header.php";
// SQL QUERY
$select = $conn->prepare("SELECT title,slug FROM articles ORDER BY RAND() limit 1");
$select->execute();
$result = $select->get_result();
$breaking_news = $result->fetch_assoc();
 ?>
<main class="min-h-screen">
    <!-- Home Side -->
    <div class="bg-red-600 py-2 text-white">
        <p class="max-w-7xl mx-auto px-2 sm:px-4 lg:px-6 text-sm text-gray-100"> <span class="px-2 py-1 bg-red-700 rounded-md mx-1">Breaking News</span>
        <a href="/post/detail.php?slug=<?php echo $breaking_news["slug"] ?>">
            <?= $breaking_news['title']; ?> 
        </a>
    </p>
    </div>
    <div class="grid grid-cols-4 px-20 gap-6 pt-1 max-w-7xl mx-auto sm:px-4 lg:px-6">
        <div class="col-span-full md:col-span-3">
            <? include "templates/home/hero/hero.php"; ?>
        </div>
        <div class="md:col-span-1">
            <? include "templates/home/hero/sidebar.php"; ?>
        </div>
    </div>
    <!-- Main news -->
     <div class="max-w-7xl mx-auto sm:px-4 lg:px-6 my-4">
        <h1 class="font-bold text-lg text-gray-700 py-4">LATEST NEWS</h1>
         <? include "templates/home/main_news.php"; ?>
     </div>
</main>

<?php include "common/footer.php"; ?>