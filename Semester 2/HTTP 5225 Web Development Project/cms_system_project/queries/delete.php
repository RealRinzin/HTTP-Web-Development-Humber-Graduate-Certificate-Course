<?php
require_once(__DIR__ . '/../config/db.php');
require_once(__DIR__ . '/../functions/delete.php');
if (isset($_GET['id'])) {
    
    $postID = $_GET['id'];

    if (deleteArticle($conn, $postID)) {
        header("Location: ../dashboard.php");
        exit();
    }

    echo "Failed to delete article.";
}
