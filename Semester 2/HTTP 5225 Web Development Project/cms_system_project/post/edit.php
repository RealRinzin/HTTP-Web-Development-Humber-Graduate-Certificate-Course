<?php
session_start();
if (!isset($_SESSION['username'])) {
    header("Location:login.php");
}
include "../common/simple_header.php";
// ID
$postID = $_GET['id'];
$select = $conn->prepare("SELECT articles.* , categories.name AS category_name,
        users.username AS author_name FROM articles
    JOIN categories ON articles.category_id = categories.id
    JOIN users ON articles.author_id = users.id WHERE articles.id = ?");
$select->bind_param("s", $postID);
$select->execute();
$result = $select->get_result();
$article = $result->fetch_assoc();

// All Authors
$authors = $conn->query("SELECT * FROM users")->fetch_all(MYSQLI_ASSOC);
$categories = $conn->query("SELECT * FROM categories")->fetch_all(MYSQLI_ASSOC);


?>
<?php
if (count($_POST) > 0) {

    $updateQuery = $conn->prepare(
        "UPDATE articles 
         SET title=?, category_id=?, author_id=?, status=?, content=? 
         WHERE id=?"
    );

    $updateQuery->bind_param(
        "siissi",
        $_POST['title'],
        $_POST['category'],
        $_POST['author'],
        $_POST['status'],
        $_POST['content'],
        $_POST['id'],
        // $_POST['status']
    );

    $updateQuery->execute();

    if ($updateQuery->affected_rows > 0) {
        // echo "Article updated successfully!";
        echo '<script>window.location.reload();</script>';
    }
}

?>
<main class="min-h-screen max-w-7xl mx-auto sm:px-20 lg:px-6 my-10 w-full md:w-1/2">
    <a href="/dashboard.php" class="py-4 text-blue-800"> <i class="fa-solid fa-chevron-left"></i> Dashboard</a>
    <form action="" method="post" class="rounded-md border border-gray-100 p-10 my-6">
        <input type="text" hidden name="id" value=<?= $article['id'] ?>>
        <div class="flex flex-col gap-4">
            <div class="flex flex-col gap-2">
                <label for="title" class="text-gray-800 font-bold">Title</label>
                <input type="text" name="title" id="title" class="rounded-md border border-gray-200 px-4 py-2" value="<?php echo $article["title"];  ?>">
            </div>
            <div class="flex flex-col gap-2">
                <label for="author" class="text-gray-800 font-bold">Author</label>
                <select name="author" id="author" class="rounded-md border border-gray-200 px-4 py-2">
                    <option value=<?= $article["author_id"] ?>><?= $article["author_name"]; ?></option>
                    <?php foreach ($authors as $index => $author): ?>
                        <option value="<?= $author["id"] ?>"> <?= $author["username"] ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
            <div class="flex flex-col gap-2">
                <label for="category" class="text-gray-800 font-bold">Cateogry</label>
                <select name="category" id="category" class="rounded-md border border-gray-200 px-4 py-2">
                    <option value=<?= $article["category_id"] ?>><?= $article["category_name"]; ?></option>
                    <?php foreach ($categories as $index => $category): ?>
                        <option value="<?= $category["id"] ?>"> <?= $category["name"] ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
            <div class="flex flex-col gap-2">
                <label for="status" class="text-gray-800 font-bold">Status</label>
                <select name="status" id="status" class="rounded-md border border-gray-200 px-4 py-2">
                    <option value="published"> Published</option>
                    <option value="archived"> Archieved</option>
                    <option value="draft"> Drafted</option>
                </select>
            </div>
            <div class="flex flex-col gap-2">
                <label for="content" class="text-gray-800 font-bold">Content</label>
                <textarea class="rounded-md border border-gray-200 p-8" id="editor" name="content">
                    <?= $article["content"]; ?>
                </textarea>
            </div>
            <div class="flex justify-center my-4">
                <button type="submit" class="py-2 px-2 rounded-md bg-gray-800 w-1/4 font-bold text-white ">Update</button>
            </div>
        </div>
    </form>
</main>

<?php include "../common/footer.php"; ?>