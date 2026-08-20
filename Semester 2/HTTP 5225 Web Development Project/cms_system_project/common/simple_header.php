<?php
require_once(__DIR__ . '/../config/db.php');
require_once(__DIR__ . '/../utils/functions.php');

if (isset($_POST['submit'])) {
    session_unset();
    session_destroy();
    header("Location: index.php");
    exit;
} ?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?php echo isset($pageTitle) ? htmlspecialchars($pageTitle) . " | The Dawn & Dust Post " : 'The Dawn & Dust Post '; ?></title>
</head>

<body>
    <header>
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
    </header>