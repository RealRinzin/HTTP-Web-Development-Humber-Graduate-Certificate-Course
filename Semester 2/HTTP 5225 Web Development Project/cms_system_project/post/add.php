<?php
session_start();
if (!isset($_SESSION['username'])) {
    header("Location:login.php");
}
include "../common/simple_header.php";

// All Authors
$authors = $conn->query("SELECT * FROM users")->fetch_all(MYSQLI_ASSOC);
$categories = $conn->query("SELECT * FROM categories")->fetch_all(MYSQLI_ASSOC);

// Slug function

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $title = $_POST['title'];
    $author = $_POST['author'];
    // Insert
    $category = $_POST['category'];
    $status = $_POST['status'];
    $content = $_POST['content'];
    // Create slug from title
    $slug = strtolower(trim($title));
    $slug = preg_replace('/[^a-z0-9]+/', '-', $slug);
    $slug = trim($slug, '-');

    $insert = $conn->prepare("
        INSERT INTO articles 
        (title,slug, author_id, category_id, status, content)
        VALUES (?, ?, ?, ?, ?,?)
    ");

    $insert->bind_param(
        "ssiiss",
        $title,
        $slug,
        $author,
        $category,
        $status,
        $content
    );

    if ($insert->execute()) {
        // header("Location: dashboard.php");
         echo "<script>window.location.reload();</script>";
        exit;
    } else {
        echo "Error: " . $insert->error;
    }
}
?>

<main class="min-h-screen max-w-7xl mx-auto sm:px-20 lg:px-6 my-10 w-full md:w-1/2">
    <a href="/dashboard.php" class="py-4 text-blue-800"> <i class="fa-solid fa-chevron-left"></i> Dashboard</a>
    <form action="" method="post" class="rounded-md border border-gray-100 p-10 my-6">
        <div class="flex flex-col gap-4">
            <div class="flex flex-col gap-2">
                <label for="title" class="text-gray-800 font-bold">Title</label>
                <input type="text" name="title" id="title" class="rounded-md border border-gray-200 px-4 py-2">
            </div>
            <div class="flex flex-col gap-2">
                <label for="author" class="text-gray-800 font-bold">Author</label>
                <select name="author" id="author" class="rounded-md border border-gray-200 px-4 py-2">
                    <?php foreach ($authors as $index => $author): ?>
                        <option value="<?= $author["id"] ?>"> <?= $author["username"] ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
            <div class="flex flex-col gap-2">
                <label for="category" class="text-gray-800 font-bold">Cateogry</label>
                <select name="category" id="category" class="rounded-md border border-gray-200 px-4 py-2">
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
                </textarea>
            </div>
            <div class="flex justify-center my-4">
                <button type="submit" class="py-2 px-2 rounded-md bg-gray-800 w-1/4 font-bold text-white ">Update</button>
            </div>
        </div>
    </form>
</main>


<?php include "../common/footer.php"; ?>