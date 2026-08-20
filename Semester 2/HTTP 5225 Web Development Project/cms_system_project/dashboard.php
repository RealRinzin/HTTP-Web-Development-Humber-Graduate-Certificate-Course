<?php
session_start();
if (!isset($_SESSION['username'])) {
    header("Location:login.php");
}
include "common/simple_header.php";

$select = $conn->prepare("SELECT articles.* , categories.name AS category_name,
        users.username AS author_name FROM articles
    JOIN categories ON articles.category_id = categories.id
    JOIN users ON articles.author_id = users.id");
$select->execute();
$result = $select->get_result();
$articles = $result->fetch_all(MYSQLI_ASSOC);



?>
<main class="min-h-screen">
    <!-- Home Side -->
    <div class="grid grid-cols-6">
        <div class="col-span-1 bg-gray-100 h-screen border-r border-gray-300/10">
            <div class="p-6">
                <h2 class="px-2 text-gray-500 text-sm uppercase">Dashboard List</h2>
                <ul class="flex flex-col  my-2 text-sm">
                    <li class="bg-gray-900 px-4 py-2 text-white"><a href="/">Posts</a></li>
                    <li class="bg-gray-100 px-4 py-2 hover:bg-gray-900 hover:text-white hover:duration-200"><a href="/">Categories</a></li>
                    <li class="bg-gray-100 px-4 py-2 hover:bg-gray-900 hover:text-white hover:duration-200"><a href="/">Contributer</a></li>
                    <li class="bg-gray-100 px-4 py-2 hover:bg-gray-900 hover:text-white hover:duration-200"><a href="/">Profile</a></li>
                    <li class="bg-gray-100 px-4 py-2 hover:bg-gray-900 hover:text-white hover:duration-200"><a href="/">Media Libraries</a></li>
                    <li class="bg-gray-100 px-4 py-2 hover:bg-gray-900 hover:text-white hover:duration-200"><a href="/">Setting</a></li>

                </ul>
            </div>
        </div>
        <div class="col-span-5 mx-10 my-4">
            <a href="/post/add.php" class="bg-red-800 w-fit text-white p-1 rounded">Add Post +</a>
            <div class="border shadow rounded-md p-4 my-6">
                <div class="flex gap-5 ">
                    <ul class="flex flex-col gap-2 my-2 border border-gray-300 py-4 px-6">
                        <li class="text-red-800 text-sm">Published</li>
                        <li class="text-center text-xl font-bold">230+</li>
                    </ul>
                    <ul class="flex flex-col gap-2 my-2 border border-gray-300 py-4 px-6">
                        <li class="text-red-800 text-sm">Archieved</li>
                        <li class="text-center text-xl font-bold">100+</li>
                    </ul>
                    <ul class="flex flex-col gap-2 my-2 border border-gray-300 py-4 px-6">
                        <li class="text-red-800 text-sm">Drafted</li>
                        <li class="text-center text-xl font-bold">23</li>
                    </ul>
                    <ul class="flex flex-col gap-2 my-2 border border-gray-300 py-4 px-6">
                        <li class="text-red-800 text-sm">Users</li>
                        <li class="text-center text-xl font-bold">10+</li>
                    </ul>
                    <ul class="flex flex-col gap-2 my-2 border border-gray-300 py-4 px-6">
                        <li class="text-red-800 text-sm">Categories</li>
                        <li class="text-center text-xl font-bold">20+</li>
                    </ul>
                </div>
                <table class="w-full text-left text-xs">
                    <thead class="bg-gray-300">
                        <tr>
                            <th class="p-3">S.No</th>
                            <th class="p-3">Title</th>
                            <th class="p-3">Author</th>
                            <th class="p-3">Category</th>
                            <th class="p-3">Content</th>
                            <th class="p-3">Status</th>
                            <th class="p-3">Published</th>
                            <th class="p-3">View</th>
                            <th class="p-3">Edit </th>
                            <th class="p-3">Delete </th>
                        </tr>
                    </thead>
                    <tbody class="">
                        <?php foreach ($articles as $index => $items): ?>
                            <tr class=" even:bg-gray-100 hover:bg-gray-200 hover:duration-200 even:border-b even:border-gray-300 cursor-pointer">
                                <td class="py-2 text-center"><?= $index + 1 ?></td>
                                <td class="p-4">
                                    <a href="/post/detail.php?slug=<?php echo $items["slug"] ?>">
                                        <?php limitContentLength($items["title"], 20) ?>
                                    </a>
                                </td>
                                <td class="p-4 text-red-800"><?= $items["author_name"] ?></td>
                                <td class="p-4 text-red-800"><?= $items["category_name"] ?></td>
                                <td class="p-4"><?php limitContentLength($items["content"], 100) ?></td>
                                <td class="p-4">
                                    <?php if ($items['status'] == 'published'): ?>
                                        <span class="border bg-green-100 border-green-400 font-medium text-gray-700 px-2 py-1 rounded">
                                            Published
                                        </span>
                                    <?php elseif ($items['status'] == 'draft'): ?>
                                        <span class="border bg-red-100 border-red-400 font-medium text-gray-700 px-2 py-1 rounded">
                                            Drafted
                                        </span>
                                    <?php else: ?>
                                        <span class="border bg-yellow-100 border-yellow-400 font-medium text-gray-700 px-2 py-1 rounded">
                                            Archieved
                                        </span>
                                    <?php endif; ?>
                                </td>
                                <td class="p-4">2026-09-09</td>
                                <td class="p-4">
                                    <a href="/post/detail.php?slug=<?php echo $items["slug"] ?>">
                                        <i class="fa-solid fa-eye text-md text-gray-700"></i>
                                    </a>
                                </td>

                                </a>
                                <td class="p-4"><a href="">
                                        <a href="/post/edit.php?id=<?php echo $items["id"] ?>">
                                            <i class="fa-solid fa-edit text-md text-sky-700"></i>
                                        </a>
                                </td>
                                <td class="p-4"><a  href="queries/delete.php?id=<?= $items['id'] ?>"
                                        onclick="return confirm('Are you sure you want to delete this article?');">
                                        <i class="fa-solid fa-trash-can text-md text-red-700"></i></a>
                                </td>
                            </tr>
                        <?php endforeach; ?>

                    </tbody>
                </table>
            </div>

        </div>
    </div>
</main>

<?php include "common/footer.php"; ?>