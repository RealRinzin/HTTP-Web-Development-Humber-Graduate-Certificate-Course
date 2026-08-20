<?php

// SQL QUERY
$select = $conn->prepare("SELECT articles.* , categories.name AS category_name,
        users.username AS author_name FROM articles
    JOIN categories ON articles.category_id = categories.id
    JOIN users ON articles.author_id = users.id ORDER BY RAND() limit 1");
$select->execute();
$result = $select->get_result();
$latest = $result->fetch_assoc();

?>
<div>
    <ul class="flex gap-3 py-2 text-xs font-semibold">
        <li class="bg-gray-200 px-2 py-1 rounded"><a href=""> <i class="fa-solid fa-earth-americas text-xs"></i>World News</a></li>
        <li class="bg-gray-200 px-2 py-1 rounded"><a href=""><i class="fa-solid fa-money-bill-1 text-xs"></i> Business</a></li>
        <li class="bg-gray-200 px-2 py-1 rounded"><a href=""> <i class="fa-solid fa-person-walking-luggage text-xs"></i>Entrepreneur</a></li>
        <li class="bg-gray-200 px-2 py-1 rounded"><a href=""> <i class="fa-brands fa-openai text-xs"></i> AI Technologies</a></li>
        <li class="bg-gray-200 px-2 py-1 rounded"><a href=""> <i class="fa-solid fa-basketball text-xs"></i> Sports</a></li>
        <li class="bg-gray-200 px-2 py-1 rounded"><a href=""> <i class="fa-solid fa-film text-xs"></i> Entertaiment</a></li>
    </ul>
    <div class="bg-[url(<?= $latest['featured_image'] . '?resize=770%2C513&quality=80' ?>)] bg-gray-900/50 bg-blend-overlay bg-cover bg-center bg-no-repeat pt-40 rounded-md">
        <div class="flex flex-col justify-end gap-4 px-10 pb-10">
            <h1 class="text-white text-2xl text-shadow-gray-100">
                <a href="/post/detail.php?slug=<?php echo $latest["slug"] ?>">
                    <?= $latest["title"]; ?>
                </a>
            </h1>
            <p class=" text-white text-shadow-2xs text-sm">
                <!-- “The United States has had a forced labor import ban for nearly a century, and rigorously enforces it; it’s well past time for our trading partners to do the same,” US Trade Representative Jamieson Greer said in a statement on Thursday. -->
                <a href="/post/detail.php?slug=<?php echo $latest["slug"] ?>">

                    <?= $latest["summary"]; ?>
                </a>
            </p>
            <ul class="flex text-sm gap-2 text-white font-medium">
                <li>Today</li>
                <li class="bg-yellow-500 rounded px-1 text-gray-800"><?= $latest["category_name"] ?></li>
            </ul>
        </div>
    </div>
    <div class="py-4">
        <p class="text-red-800 font-medium">World News</p>
        <h1 class="text-gray-800 text-2xl text-shadow-gray-100">
            <a href="">Trump’s latest ‘forced labour tariffs’: Who’s been hit, how badly?</a>
        </h1>
        <p class="py-4 font-medium text-gray-700">
            <a href="">
                The United States has had a forced labor import ban for nearly a century, and rigorously enforces it; it’s well past time for our trading partners to do the same,” US Trade Representative Jamieson Greer said in a statement on Thursday.
            </a>
        </p>
        <p class="text-xs text-gray-400">
            By<span class="font-medium text-gray-500">Tenzin Rinzin</span>Toronto · 8 min read</p>
    </div>
</div>