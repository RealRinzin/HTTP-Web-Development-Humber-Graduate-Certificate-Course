<?php
// api.php — Increment all counters by 1000 and return current totals
header('Content-Type: application/json');
require 'db.php';

// Increment all counters by 1000
mysqli_query($conn, "UPDATE banana_counter SET
    human      = human      + 9500,
    monkey     = monkey     + 57870,
    elephant   = elephant   + 58,
    chimpanzee = chimpanzee + 52
WHERE id = 1");

// Return updated values
$result = mysqli_query($conn, "SELECT human, monkey, elephant, chimpanzee FROM banana_counter WHERE id = 1");
$row = mysqli_fetch_assoc($result);
echo json_encode($row);

mysqli_close($conn);
