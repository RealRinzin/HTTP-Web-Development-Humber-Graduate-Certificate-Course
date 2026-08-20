<?php
$pageTitle = $_GET['slug'];
include "../common/header.php";
require_once(__DIR__ . '/../config/db.php');
$slug = $_GET['slug'];
$select = $conn->prepare("SELECT articles.* , categories.name AS category_name,
        users.username AS author_name FROM articles
    JOIN categories ON articles.category_id = categories.id
    JOIN users ON articles.author_id = users.id WHERE articles.slug = ?");
$select->bind_param("s", $slug);
$select->execute();
$result = $select->get_result();
$article = $result->fetch_assoc();
?>
<main class="min-h-screen max-w-7xl mx-auto sm:px-4 lg:px-6">
    <div class="md:w-2/3 mx-auto">
        <p class="text-xs font-bold text-red-800 py-2 uppercase text-center">
            <?= $article['category_name'] ?>
        </p>
        <h1 class="flex justify-center text-5xl font-bold text-gray-900 text-center my-4">
            <?= $article["title"] ?>
        </h1>
        <div class="flex justify-between items-center gap-2 my-2 border-y border-gray-300 py-6">
            <ul class="flex gap-3">
                <li class="h-10 w-10 rounded-full border border-gray-200 bg-gray-100"></li>
                <li class="flex flex-col gap-1 ">
                    <span class="text-gray-800 font-medium text-sm"><?= $article['author_name'] ?></span>
                    <span class="text-gray-600 text-xs">Senior Correspondent - Toronto</span>
                </li>
            </ul>
            <ul class="flex gap-3 items-center">
                <li class="text-xs text-gray-600">Published July 2028, 2026 8 min read</li>
                <li class="border border-gray-300 px-2 py-1 text-gray-500 text-xs font-medium"><a href="">Share</a></li>
                <li class="border border-gray-300 px-2 py-1 text-gray-500 text-xs font-medium"><a href="">Save</a></li>
                <li class="border border-gray-300 px-2 py-1 text-gray-500 text-xs font-medium"><a href="">Gift</a></li>
            </ul>
        </div>
        <figure>
            <!-- <img src="https://images.unsplash.com/photo-1517649763962-0c623066013b" alt="" height="400px"> -->
            <img src="<?= $article["featured_image"] ?>" alt="" height="400px">
            <figcaption class="bg-gray-50 text-xs text-gray-500 font-medium py-1 px-2">Fig.1 - Trulli, Puglia, Italy.</figcaption>
        </figure>
        <!-- Gripd -->
        <section class="grid grid-cols-1 md:grid-cols-3 gap-4 my-10 ">
            <article class="md:col-span-2 flex flex-col gap-6 text-base leading-7 text-gray-800 ">
                <?= $article["content"] ?>
            </article>
            <div class="md:col-span-1">
                <?php
                require_once(__DIR__ . '/../templates/home/hero/sidebar.php');
                ?>
            </div>
        </section>
    </div>
</main>
<?php include "../common/footer.php"; ?>