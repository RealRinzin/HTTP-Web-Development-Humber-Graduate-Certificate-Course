<?php
session_start();

if (!isset($_SESSION['username'])) {
    header("Location:index.php");
}
// Unset all session variables

if (isset($_POST['submit'])) {
    session_unset();
    session_destroy();
    header("Location: index.php");
    exit;
}

?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Admin Dashboard</title>
</head>

<body>
    <header class="bg-blue-700 px-20 py-6 text-white">
        <nav class="flex justify-between">
            <h1 class="font-bold">Admin Dashboard</h1>
            <ul class="flex items-center font-bold gap-4">
                <li class="text-white text-sm font-semibold my-2"> Welcome <?php echo $_SESSION['username'] ?></li>
                <li>
                    <form action="#" method="post">
                        <button type="submit" name="submit" class="cursor-pointer">Logout</button>
                    </form>
                </li>
            </ul>
        </nav>
    </header>
    <main class="px-20 py-4">
        <h2 class="text-gray-700 font-semibold text-md">Technology News</h2>
        <h2 class="text-gray-700 text-2xl font-bold">Branching databases like code: a CI/CD pattern for Lakebase, in production at Glaspoort</h2>
        <p class="text-gray-600 font-normal py-4">
            Glaspoort builds and operates fiber infrastructure in the Netherlands. Everything revolves around growing the number of fiber connections, and for a long time the data team spent its days building BI reports in support of that goal, while the question behind each report was already outdated by the time the report was finished. The result was a sprawl of one-off reports, and users who had nowhere to take their follow-up questions.
        <p class="text-gray-600 font-normal py-4">
            So we broke the dependency. Instead of shipping the next report, we built a custom front-end application in which project managers see directly where the opportunities for their projects lie. What is new sits under the hood: we use Databricks products directly as building blocks in the app. Genie, to chat with the data and spin up quick analyses. AI/BI Dashboards, for insights and self-service analytics. Automated workflows with Agent Bricks, which alert project managers the moment something stands out on their projects and Lakebase, the Databricks OLTP database, for the application's transactional data.
        </p>
        <p class="text-gray-600 font-normal py-4">
            That combination brings together two worlds that until recently lived apart: the analytical environment and an operational front-end, where analytical data meets transactional data. The data team now spends its time on Genie spaces and metadata instead of one-off reports. But none of this stays fast without a serious foundation underneath: CI/CD, data-quality testing, Infrastructure as Code, and data governance. One piece of that foundation took the most careful design, and it is the piece the rest of this story is about: how we ship changes to the database behind the app.
        </p>
        <p class="text-gray-600 font-normal py-4">
            Behind that application sits a Databricks Lakebase database. It is serverless Postgres OLTP, running next to the lakehouse rather than bolted onto it. The data flow is simple to describe and, as we found out, more interesting to operate than it looks:
        </p>
        <ul class="flex flex-col gap-2 list-disc text-gray-600 mx-2">
            <li>
                Curated data from the lakehouse is synced into a Lakebase production branch, where it lands in a read-only application schema.
            </li>
            <li>
                The application writes its own state back into a separate schema on that same branch, so the data read from the lakehouse and the data written by the app live side by side without colliding.
            </li>
            <li>

                On top of that we run three logical environments: development, acceptance, and production. We ship changes to this database the same way we ship changes to application code, through pull requests, CI, and gated promotion.
            </li>
        </ul>
    </main>
    <script src="https://cdn.tailwindcss.com"></script>
    <script src="https://cdn.jsdelivr.net/npm/tailwindcss@4.3.1/dist/lib.min.js"></script>
</body>

</html>
<!-- <!DOCTYPE html>
<html>

<head></head>

<body>


    <div>
        <p>Welcome, <?php echo $_SESSION['username'] ?>
        <form action="#" method="post">
            <button type="submit" name="submit">Logout</button>
        </form>
        </p>
    </div>

</body>

</html> -->