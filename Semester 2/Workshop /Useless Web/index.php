<?php
// index.php — Banana Counter
require 'db.php';
$result = mysqli_query($conn, "SELECT human, monkey, elephant, chimpanzee FROM banana_counter WHERE id = 1");
$row = mysqli_fetch_assoc($result);
$total = $row['human'] + $row['monkey'] + $row['elephant'] + $row['chimpanzee'];
mysqli_close($conn);
?>
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <title>🍌 Banana Counter</title>
<link rel="stylesheet" href="./assets/css/style.css">
</head>

<body>

  <div class="banana-icon">
    <img src="./assets/svg/banana-svgrepo-com.svg" height="200">
  </div>
  <h1>BANANA COUNTER</h1>
  <div class="since">SINCE 1970-1-1</div>
  <div class="total" id="total"><?= number_format($total) ?></div>

  <div class="cards">
    <div class="card">
      <img src="./assets/img/baby.png" height="200px" alt="">

      <div class="label">Human</div>
      <div class="count" id="human"><?= number_format($row['human']) ?></div>
    </div>
    <div class="card">
      <img src="./assets/img/monkey.png" height="200px" alt="">
      <div class="label">Monkey</div>
      <div class="count" id="monkey"><?= number_format($row['monkey']) ?></div>
    </div>
    <div class="card">
      <img src="./assets/img/chimp.png" height="200px" alt="">

      <div class="label">Chimpanzee</div>
      <div class="count" id="chimpanzee"><?= number_format($row['chimpanzee']) ?></div>
    </div>
    <div class="card">
      <img src="./assets/img/elephant.png" height="200px" alt="">
      <div class="label">Elephant</div>

      <div class="count" id="elephant"><?= number_format($row['elephant']) ?></div>
    </div>
  </div>

  <script>
    function fmt(n) {
      return Number(n).toLocaleString();
    }
    
    setInterval(async () => {
      try {
        const res = await fetch('api.php');
        const d = await res.json();
        document.getElementById('human').textContent = fmt(d.human);
        document.getElementById('chimpanzee').textContent = fmt(d.chimpanzee);
        document.getElementById('elephant').textContent = fmt(d.elephant);
        document.getElementById('monkey').textContent = fmt(d.monkey);
        const total = +d.human + +d.chimpanzee + +d.elephant + +d.monkey;
        document.getElementById('total').textContent = fmt(total);
      } catch (e) {
        console.error('Update failed', e);
      }
    }, 1000);
  </script>

</body>

</html>