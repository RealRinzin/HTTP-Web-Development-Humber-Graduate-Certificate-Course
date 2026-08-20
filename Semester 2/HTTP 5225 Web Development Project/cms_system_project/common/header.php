<?php
session_start();
require_once(__DIR__ . '/../config/db.php');
if (isset($_POST['submit'])) {
    session_unset();
    session_destroy();
    header("Location: index.php");
    exit;
}
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?php echo isset($pageTitle) ? htmlspecialchars($pageTitle) . '| The Dawn & Dust Post ' : 'The Dawn & Dust Post '; ?></title>
</head>

<body>
    <header class="">
        <div class="py-2 bg-gray-50">
            <div class="flex justify-between max-w-7xl mx-auto px-2 sm:px-4 lg:px-6">
                <p class="text-xs gray-gray-500">
                    <?php echo date('l, F j, Y'); ?>
                </p>
                <ul class="flex gap-4 text-sm">
                    <li><a href="/">Today's paper</a></li>
                    <li><a href="/">Newsletters</a></li>
                    <li><a href="/">Podcasts</a></li>
                    <li><a href="/">Subscribe</a></li>
                    <?php if (!isset($_SESSION['username'])): ?>
                        <li class="font-medium"><a href="/login.php">Login</a></li>
                    <? else: ?>
                        <li class="font-medium text-xs bg-gray-600 text-white px-2 rounded flex items-center">
                            <form action="#" method="post">
                                <button type="submit" name="submit" class="cursor-pointer">Logout</button>
                            </form>
                        </li>
                        <li class="text-xs bg-red-800 text-white px-2 rounded flex items-center"><a href="/dashboard.php">Dashboard</a></li>
                    <?php endif ?>
                </ul>
            </div>
        </div>
        <div class="flex justify-center flex-col items-center gap-1 py-10  border-y border-gray-200">
            <h1 class="text-5xl text-gray-800 font-medium">
                <a href="/">

                    The Dawn & Dust Post
                </a>
            </h1>
            <p class="text-gray-600 text-sm">News without borders and races.</p>
        </div>
        <nav class="flex justify-between items-center py-4 max-w-7xl mx-auto px-2 sm:px-4 lg:px-6">
            <ul class="hidden md:flex gap-4 text-sm">
                <li class="hover:text-red-700 duration-200hover:duration-100"><a href="">World</a></li>
                <li class="hover:text-red-700 duration-200hover:duration-100"><a href="">Business</a></li>
                <li class="hover:text-red-700 duration-200hover:duration-100"><a href="">Technology</a></li>
                <li class="hover:text-red-700 duration-200hover:duration-100"><a href=""> Sports</a></li>
                <li class="hover:text-red-700 duration-200hover:duration-100"><a href="">Entertainment</a></li>
                <li class="hover:text-red-700 duration-200hover:duration-100"><a href=""><i class="fa-solid fa-circle-user text-white text-xl"></i></a></li>
            </ul>
        </nav>
    </header>