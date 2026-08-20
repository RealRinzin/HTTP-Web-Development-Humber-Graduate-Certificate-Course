<?php


// Limit the text length
function limitContentLength($content, $limit)
{
    $short_text = substr($content, 0, $limit);
    echo  $short_text."...";
}
