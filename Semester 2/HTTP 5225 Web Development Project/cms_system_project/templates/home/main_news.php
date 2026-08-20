<?php
require_once "components/cards/squareNewsCard.php";
require_once(__DIR__ . '/../../config/db.php');
$select = $conn->prepare("SELECT articles.* , categories.name AS category_name,
        users.username AS author_name FROM articles
    JOIN categories ON articles.category_id = categories.id
    JOIN users ON articles.author_id = users.id  ORDER BY RAND() limit 6");
$select->execute();
$result = $select->get_result();
$articles = $result->fetch_all(MYSQLI_ASSOC);
?>
<div class="grid grid-cols-4 gap-10">
    <div class="col-span-full md:col-span-3">
        <div class="grid grid-cols-2 gap-6">
            <?php squareNewsCard($articles); ?>
        </div>
    </div>
    <div class="md:col-span-1">
        <h1 class="text-gray-600 text-sm font-medium">MOST READ</h1>
        <?php foreach ($articles as $index => $items): ?>
            <ul class="flex justify-between gap-4 py-4 border-b border-gray-200">
                <li class=" font-bold text-red-800 text-2xl">
                    <?= $index + 1 ?>
                </li>
                <li class="font-medium text-sm text-gray-800 hover:text-red-800 duration-200">
                    <a href="/post/detail.php?slug=<?php echo $items["slug"] ?>"> <?php limitContentLength($items["title"], 50) ?> </a>
                    <p class="text-xs text-red-800 py-1">
                        <a href="">
                            <?= $items["category_name"] ?>

                        </a>
                    </p>
                </li>
            </ul>
        <?php endforeach; ?>
    </div>
</div>