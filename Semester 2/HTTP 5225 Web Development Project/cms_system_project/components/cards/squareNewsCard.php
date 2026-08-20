<?php
function squareNewsCard($news){ ?>
    <?php foreach ($news as $latest): ?>
        <div class="my-2">
            <div class="h-40 bg-[url(<?php echo $latest["featured_image"] ?>)] bg-cover bg-center bg-no-repeat rounded"></div>
            <p class="text-xs font-bold text-red-800 py-2 uppercase">
                <a href="">
                    <?php echo $latest['category_name'] ?>
                </a>
            </p>
            <p class="font-bold text-lg text-gray-800 py-2 hover:text-red-800">
                <a href="/post/detail.php?slug=<?php echo $latest["slug"];?>"><?php limitContentLength($latest["title"], 40) ?></a>
            </p>
            <p class="hover:text-red-800">
                <a href="/post/detail.php?slug=<?php echo $latest["slug"];?>">
                    <?php limitContentLength($latest["content"], 100) ?>
                </a>
            </p>
            <p class="text-xs text-gray-400">18 min ago</p>
        </div>

    <?php endforeach; ?>
<?php } ?>