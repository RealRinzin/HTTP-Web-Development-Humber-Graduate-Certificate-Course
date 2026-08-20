-- ============================================================
-- Assignment 1 - PHP and MySQL
-- Database: survival_jobs
-- Tables:
--   1. company
--   2. survival_jobs
-- Relationship:
--   One Company -> Many Jobs
-- ============================================================

CREATE DATABASE IF NOT EXISTS jobs;
USE jobs;

-- Drop tables in correct order
DROP TABLE IF EXISTS jobs;
DROP TABLE IF EXISTS company;

-- ============================================================
-- COMPANY TABLE
-- ============================================================

CREATE TABLE company (
    id      INT(11) NOT NULL AUTO_INCREMENT,
    company_name    VARCHAR(100) NOT NULL,
    city            VARCHAR(100) NOT NULL,
    province        VARCHAR(100) NOT NULL,
    phone           VARCHAR(20),
    email           VARCHAR(100),
    PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Insert 20 companies

INSERT INTO company
(company_name, city, province, phone, email)
VALUES
('Happy Paws Services',      'Toronto',      'Ontario', '416-555-1001', 'info@happypaws.ca'),
('Little Stars Childcare',   'Mississauga',  'Ontario', '905-555-1002', 'jobs@littlestars.ca'),
('Content Creators Inc.',    'Brampton',     'Ontario', '905-555-1003', 'hr@contentcreators.ca'),
('Quick Eats Delivery',      'Toronto',      'Ontario', '416-555-1004', 'careers@quickeats.ca'),
('Sparkle Clean Homes',      'Vaughan',      'Ontario', '905-555-1005', 'jobs@sparkleclean.ca'),
('Fresh Cart Services',      'Oakville',     'Ontario', '905-555-1006', 'hr@freshcart.ca'),
('Bright Minds Tutoring',    'Hamilton',     'Ontario', '905-555-1007', 'jobs@brightminds.ca'),
('Pixel Perfect Design',     'Toronto',      'Ontario', '416-555-1008', 'careers@pixelperfect.ca'),
('RideNow Transport',        'Mississauga',  'Ontario', '905-555-1009', 'drivers@ridenow.ca'),
('Green Lawn Experts',       'Burlington',   'Ontario', '905-555-1010', 'jobs@greenlawn.ca'),
('Premier Event Staffing',   'Toronto',      'Ontario', '416-555-1011', 'staff@premierevents.ca'),
('Virtual Office Solutions', 'Ottawa',       'Ontario', '613-555-1012', 'careers@vos.ca'),
('Easy Move Helpers',        'Brampton',     'Ontario', '905-555-1013', 'jobs@easymove.ca'),
('Social Buzz Media',        'Toronto',      'Ontario', '416-555-1014', 'hr@socialbuzz.ca'),
('Pet Care Plus',            'Guelph',       'Ontario', '519-555-1015', 'jobs@petcareplus.ca'),
('DataWorks Canada',         'London',       'Ontario', '519-555-1016', 'careers@dataworks.ca'),
('Fix-It Home Services',     'Kitchener',    'Ontario', '519-555-1017', 'jobs@fixit.ca'),
('Focus Photography',        'Toronto',      'Ontario', '416-555-1018', 'info@focusphoto.ca'),
('Customer Connect',         'Ottawa',       'Ontario', '613-555-1019', 'hr@customerconnect.ca'),
('NorthStar Warehousing',    'Brampton',     'Ontario', '905-555-1020', 'jobs@northstar.ca');

-- ============================================================
-- SURVIVAL JOBS TABLE
-- ============================================================

CREATE TABLE jobs (
    id          INT(11) NOT NULL AUTO_INCREMENT,
    company_id      INT(11) NOT NULL,
    job_title       VARCHAR(100) NOT NULL,
    category        VARCHAR(50) NOT NULL,
    hourly_rate     DECIMAL(6,2) NOT NULL,
    is_remote       TINYINT(1) NOT NULL DEFAULT 0,
    skill_level     VARCHAR(20) NOT NULL,
    date_posted     DATE NOT NULL,
    description     TEXT NOT NULL,
    PRIMARY KEY (id),

    CONSTRAINT fk_job_company
        FOREIGN KEY (company_id)
        REFERENCES company(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE

) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- INSERT 20 JOB RECORDS
-- ============================================================

INSERT INTO jobs
(company_id, job_title, category, hourly_rate, is_remote, skill_level, date_posted, description)
VALUES
(1,  'Dog Walker',            'Pet Care',          18.50, 0, 'Beginner',     '2024-01-05', 'Walk dogs in local neighborhoods. Must be comfortable with all breeds and sizes.'),
(2,  'Babysitter',            'Child Care',        20.00, 0, 'Beginner',     '2024-01-10', 'Look after children ages 3-10 during evenings and weekends. First aid certificate a plus.'),
(3,  'Freelance Writer',      'Creative',          35.00, 1, 'Intermediate', '2024-01-15', 'Write blog posts and articles for small businesses. Strong grammar skills required.'),
(4,  'Food Delivery',         'Delivery',          16.75, 0, 'Beginner',     '2024-01-20', 'Deliver meals using a bicycle or car. Flexible hours, keep 100% of tips.'),
(5,  'House Cleaner',         'Cleaning',          22.00, 0, 'Beginner',     '2024-02-01', 'Clean residential homes on a weekly or bi-weekly schedule. Supplies provided.'),
(6,  'Grocery Shopper',       'Delivery',          17.25, 0, 'Beginner',     '2024-02-05', 'Shop and deliver groceries for elderly or busy clients. Must have a reliable vehicle.'),
(7,  'Tutor',                 'Education',         40.00, 1, 'Intermediate', '2024-02-10', 'Tutor high school students in math and science. Online sessions via video call.'),
(8,  'Graphic Designer',      'Creative',          45.00, 1, 'Intermediate', '2024-02-14', 'Create logos and social media assets for startups. Portfolio required.'),
(9,  'Rideshare Driver',      'Transport',         19.00, 0, 'Beginner',     '2024-02-20', 'Drive passengers using your own vehicle. Set your own hours, earn nightly bonuses.'),
(10, 'Lawn Care',             'Outdoor',           21.50, 0, 'Beginner',     '2024-03-01', 'Mow lawns and trim hedges for residential clients. Equipment provided by employer.'),
(11, 'Event Staff',           'Hospitality',       18.00, 0, 'Beginner',     '2024-03-05', 'Work weddings and corporate events as serving or setup staff. Weekends mostly.'),
(12, 'Virtual Assistant',     'Admin',             30.00, 1, 'Intermediate', '2024-03-10', 'Manage emails, calendars and data entry for busy executives. Remote and flexible.'),
(13, 'Moving Helper',         'Labour',            25.00, 0, 'Beginner',     '2024-03-15', 'Help clients pack, load and unload moving trucks. Must be physically fit.'),
(14, 'Social Media Manager',  'Creative',          38.00, 1, 'Intermediate', '2024-03-20', 'Run Instagram and TikTok accounts for local businesses. Content creation skills needed.'),
(15, 'Pet Sitter',            'Pet Care',          20.50, 0, 'Beginner',     '2024-04-01', 'Stay overnight at clients homes to care for pets. Must love animals.'),
(16, 'Data Entry Clerk',      'Admin',             16.00, 1, 'Beginner',     '2024-04-05', 'Enter and verify data in spreadsheets for a logistics company. Accuracy is key.'),
(17, 'Handyperson',           'Trades',            42.00, 0, 'Intermediate', '2024-04-10', 'Complete minor home repairs including painting, assembly and fixture installation.'),
(18, 'Photography Assistant', 'Creative',          28.00, 0, 'Beginner',     '2024-04-15', 'Assist a professional photographer at events. Help with lighting and equipment.'),
(19, 'Call Centre Agent',     'Customer Service',  19.50, 1, 'Beginner',     '2024-04-20', 'Handle inbound customer calls for an e-commerce company. Training provided.'),
(20, 'Warehouse Associate',   'Labour',            20.00, 0, 'Beginner',     '2024-05-01', 'Pick, pack and ship orders in a distribution centre. Day and evening shifts available.');