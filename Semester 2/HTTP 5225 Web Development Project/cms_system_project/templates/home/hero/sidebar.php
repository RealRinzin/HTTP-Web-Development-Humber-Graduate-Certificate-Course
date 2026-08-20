<?php 
require_once(__DIR__ . '/../../../utils/functions.php'); 

$select = $conn->prepare("SELECT articles.* , categories.name AS category_name,
        users.username AS author_name FROM articles
    JOIN categories ON articles.category_id = categories.id
    JOIN users ON articles.author_id = users.id ORDER BY RAND() limit 4");
$select->execute();
$result = $select->get_result();
$articles = $result->fetch_all(MYSQLI_ASSOC);
?>
<h1 class="font-medium text-gray-400 pt-2 text-sm">TOP STORIES <i class="fa-solid fa-arrow-trend-up"></i></h1>
<?php foreach ($articles as $y => $items): ?>
    <div class="flex gap-3 border-b border-gray-300 py-4">
        <div class="flex flex-col basis-1/2">
            <p class="text-xs font-bold text-red-800 py-2 uppercase">
                <a href="/category/category.php?slug=<?php echo $items["title"]?>">
                    <!-- TECHNOLOGY -->
                    <?php echo $items['category_name'] ?>
                </a>
            </p>
            <h2 class="font-medium text-sm text-gray-800">
                <a href="/post/detail.php?slug=<?php echo $items["slug"] ?>" class="hover:text-red-800 duration-200">
                    <?php limitContentLength($items["title"], 50); ?>

                </a>
            </h2>
        </div>
        <div class=" basis-1/2 h-20 w-20 bg-[url(<?php echo $items["featured_image"] ?>)] bg-cover bg-center bg-no-repeat">
        </div>
    </div>
<?php endforeach; ?>