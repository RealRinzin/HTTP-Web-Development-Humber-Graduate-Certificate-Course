# Job Portal Admin (HTTP5222 Assignment 1)

A simple Express + MongoDB admin app. It has two collections:

- **Companies** — `name`, `description`
- **Jobs** — `title`, `description`, `role`, `company` (reference to a Company)

Admin pages (built with Pug) let you add and delete data from both collections.
There are also two JSON API endpoints that return the collections as arrays.

## Project structure

```
job-portal-admin/
  models/
    Company.js
    Job.js
  views/
    layout.pug
    index.pug
    companies.pug
    jobs.pug
  public/
    style.css
  server.js
  package.json
  .env.example
```

## Setup

1. Install dependencies:
   ```
   npm install
   ```
2. Create a `.env` file (copy `.env.example`) and add your MongoDB Atlas connection string:
   ```
   MONGO_URI=your_connection_string_here
   PORT=3000
   ```
3. Run the app:
   ```
   npm start
   ```
4. Visit `http://localhost:3000`

## Admin pages

- `/` — dashboard with links
- `/companies` — add / view / delete companies
- `/jobs` — add / view / delete jobs (pick a company from a dropdown)

## API endpoints

- `GET /api/companies` — returns all companies as JSON
- `GET /api/jobs` — returns all jobs as JSON (with company info populated)

## Deployment

Add the deployed URL here once the app is deployed (e.g. Render, Railway, etc.):

```
Deployed URL: <add link here>
```

Make sure MongoDB Atlas Network Access allows access from anywhere (0.0.0.0/0) so the
deployed app and grader can connect.
