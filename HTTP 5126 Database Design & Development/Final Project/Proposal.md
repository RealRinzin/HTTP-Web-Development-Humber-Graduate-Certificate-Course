# Online Video Learning Platform | Humber
>## Project Purpose
> I have been developing a online interactive learning platform for the humber Gaming Department. The purpose of the project is to research the student's interactive with the online learning through video platform such as attention span, clicks, pauses, repeat watch, substitle requirements, fullscreen status and retention of the lessons on specific topics

>##  Database Tables
> 1. users
> 1. videos
> 1. topics
> 1. user_videos
> 1. user_video_watch_historiess
> 1. quizzes
> 1. documents
> 1. codes
> 1. user_quizees

>## Problems and Features
> 1. User can watch the videos
> 2. User can interact with the videos such as fast forward, rewind, pause, full screen and rewatch
> 3. 


Nice — this is a solid real-world style project. Let’s turn your idea into a **clean, well-structured MySQL database design + features** that will score high (especially for normalization, constraints, and advanced features like triggers & procedures).

---

# 🧠 1. Core System Understanding

You are basically building a **learning/video platform**, similar to parts of YouTube or Udemy.

Key ideas:

* Users watch videos
* Videos belong to topics
* Track **user interactions** (pause, rewind, etc.)
* Store quizzes, documents, code
* Track user progress

---

# 🧱 2. Database Tables (Refined Structure)

Let’s fix naming + relationships (important for normalization).

## ✅ 1. users

```sql
id (PK)
name
email (UNIQUE)
password
role (ENUM: admin, student)
created_at
```

---

## ✅ 2. topics

```sql
id (PK)
title
description
```

---

## ✅ 3. videos

```sql
id (PK)
topic_id (FK → topics.id)
title
description
url
duration
created_at
```

---

## ✅ 4. user_videos (progress tracking)

```sql
id (PK)
user_id (FK → users.id)
video_id (FK → videos.id)
progress (in seconds)
completed (BOOLEAN)
last_watched_at
```

👉 This table tracks:

* how much user watched
* completion status

---

## ✅ 5. user_video_watch_histories (interaction logs)

```sql
id (PK)
user_id (FK)
video_id (FK)
action_type (ENUM: play, pause, rewind, forward, fullscreen)
timestamp_seconds
created_at
```

👉 This is VERY important for your feature:

* rewind
* pause
* fast forward

---

## ✅ 6. quizzes

```sql
id (PK)
video_id (FK)
question
option_a
option_b
option_c
option_d
correct_answer
```

---

## ✅ 7. user_quizzes

```sql
id (PK)
user_id (FK)
quiz_id (FK)
selected_answer
is_correct
attempted_at
```

---

## ✅ 8. documents

```sql
id (PK)
video_id (FK)
title
file_url
```

---

## ✅ 9. codes

```sql
id (PK)
video_id (FK)
title
code_snippet (TEXT)
language
```

---

# 🔗 3. Relationships (Important for marks)

* 1 User → many user_videos

* 1 Video → many users
  👉 (Many-to-Many via `user_videos`)

* 1 Topic → many Videos

* 1 Video → many Quizzes / Documents / Codes

---

# ⚙️ 4. Constraints (MUST INCLUDE)

Examples:

```sql
ALTER TABLE users ADD CONSTRAINT unique_email UNIQUE (email);

ALTER TABLE user_videos 
ADD CONSTRAINT unique_user_video UNIQUE (user_id, video_id);
```

👉 Prevent duplicate progress records

---

# 🧮 5. Normalization (Explain in report)

You should mention:

* **1NF** → No repeating groups
* **2NF** → No partial dependency
* **3NF** → No transitive dependency

Example:

* `videos` table does NOT store topic name → uses `topic_id`
  ✔️ Good normalization

---

# 👁️ 6. Views (Important)

## Example: User Progress View

```sql
CREATE VIEW user_progress AS
SELECT 
    u.name,
    v.title,
    uv.progress,
    uv.completed
FROM user_videos uv
JOIN users u ON u.id = uv.user_id
JOIN videos v ON v.id = uv.video_id;
```

---

# 🔁 7. Triggers

## Example: Auto mark video complete

```sql
DELIMITER $$

CREATE TRIGGER mark_completed
BEFORE UPDATE ON user_videos
FOR EACH ROW
BEGIN
    IF NEW.progress >= (SELECT duration FROM videos WHERE id = NEW.video_id) THEN
        SET NEW.completed = TRUE;
    END IF;
END $$

DELIMITER ;
```

---

# ⚙️ 8. Stored Procedure

## Example: Insert watch history

```sql
DELIMITER $$

CREATE PROCEDURE add_watch_history(
    IN p_user_id INT,
    IN p_video_id INT,
    IN p_action VARCHAR(20),
    IN p_time INT
)
BEGIN
    INSERT INTO user_video_watch_histories
    (user_id, video_id, action_type, timestamp_seconds)
    VALUES (p_user_id, p_video_id, p_action, p_time);
END $$

DELIMITER ;
```

---

# 🔢 9. Function Example

## Get completion percentage

```sql
DELIMITER $$

CREATE FUNCTION get_completion_percentage(p_user_id INT, p_video_id INT)
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE progress INT;
    DECLARE duration INT;

    SELECT uv.progress, v.duration 
    INTO progress, duration
    FROM user_videos uv
    JOIN videos v ON v.id = uv.video_id
    WHERE uv.user_id = p_user_id AND uv.video_id = p_video_id;

    RETURN (progress / duration) * 100;
END $$

DELIMITER ;
```

---

# 🎯 10. Features Mapping (IMPORTANT FOR REPORT)

| Feature      | Implementation                |
| ------------ | ----------------------------- |
| Watch video  | `user_videos.progress`        |
| Pause / Play | `watch_histories.action_type` |
| Rewind       | `timestamp_seconds`           |
| Fast forward | same                          |
| Fullscreen   | stored as action              |
| Rewatch      | multiple history entries      |

---

# 🚀 11. Bonus Ideas (HIGH MARKS)

Add:

* **Indexes**

```sql
CREATE INDEX idx_user_video ON user_videos(user_id, video_id);
```

* **Soft delete**
* **Last activity tracking**
* **Quiz score aggregation**

---

# 🧾 12. Report Structure (for submission)

1. Introduction
2. ER Diagram
3. Table Design
4. Normalization
5. Constraints
6. Views
7. Triggers
8. Stored Procedures
9. Functions
10. Conclusion

---

# 💡 Final Tip

Your project will stand out if you:

* Clearly justify design decisions
* Show **real-world mapping**
* Keep naming consistent (fix typo: `user_video_watch_historiess` ❌)

---

If you want next step, I can:
✅ Draw ER diagram
✅ Generate full SQL script
✅ Help connect this with your **Laravel + Next.js project**

Just tell me 👍
