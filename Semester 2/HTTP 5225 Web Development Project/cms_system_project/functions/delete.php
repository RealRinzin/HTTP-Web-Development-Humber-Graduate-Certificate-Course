<?php

function deleteArticle($conn, $postID)
{
    $delete = $conn->prepare("DELETE FROM articles WHERE id = ?");
    $delete->bind_param("i", $postID);

    return $delete->execute();
}