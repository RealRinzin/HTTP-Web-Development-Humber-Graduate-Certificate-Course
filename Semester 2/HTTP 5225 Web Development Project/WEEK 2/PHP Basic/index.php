<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PHP Basic</title>
</head>
<body>
    
    <?php
echo $_GET['color'];
    $date = new DateTime();
    echo "<p>Current date and time: " . $date->format('Y-m-d H:i:s') . "</p>";
    $students = array(
        ["name" => "Tenzin Rinzin", "age" => 30, "isStudent" => true],
        ["name" => "John Doe", "age" => 25, "isStudent" => false],
        ["name" => "Jane Smith", "age" => 28, "isStudent" => true]
    );


    
    echo "<h1>Welcome to PHP Basics</h1>";
    foreach ($students as $student) {
        echo "<p>Name: " . $student['name'] . "</p>";
        echo "<p>Age: " . $student['age'] . "</p>";
        echo "<p style='color: " . ($student['isStudent'] ? "green" : "red") . ";'>Is Student: " . ($student['isStudent'] ? "Yes" : "No") . "</p>";

    }

    ?>
</body>

</html>