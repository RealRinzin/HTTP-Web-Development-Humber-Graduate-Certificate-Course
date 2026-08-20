//IMPORT REQUIRED MODULES
import express from "express";
import path from "path"; //the path module has useful methods for file path manipulation
import { MongoClient, ObjectId } from "mongodb";

//Connect to the DB
const dbEndpoing = "mongodb+srv://user:cvbkb1UsAvRupP5l@mongodb.byhxl87.mongodb.net/?appName=mongoDB";
const db = new MongoClient(dbEndpoing).db("testdb"); //Connect via a new client and select the "testdb" database

const __dirname = import.meta.dirname; //for ES6, the app root directory is found under import.meta.dirname (for ES5, you could just write __dirname)

//Set up Express app and define app port number
const app = express(); //create an Express app and store in "app" variable
const port = process.env.PORT || 9002;

//Set up app to use Pug as the template engine
//app.set("views", path.join(__dirname, "templates")); //if you had your views/templates in a folder named "templates", this is how to tell Express where to find those files
app.set("view engine", "pug");

//Set up the "public" folder as a static path
app.use(express.static(path.join(__dirname, "public")));

//You need the following two lines of code if you want to access GET or POST data as if they were JSON objects
//Set Express to extend the URLencoded format and use JSON
app.use(express.urlencoded({ extended: true }));
app.use(express.json());

//You can write a snippet of middleware to run a snippet of code on every page request
app.use(async (request, response, next) => {
  let links = await getLinks();
  app.locals.menu = links;
  next();
});

//Home page
app.get("/", (request, response) => {
  /* let links = await getLinks();
  response.render("index", { title: "Home", menu: links }); */
  response.render("index", { title: "Home" });
});
//About page
app.get("/about", (request, response) => {
  response.render("about", { title: "About" });
});

//ADMIN PAGES
app.get("/admin/menu", (request, response) => {
  response.render("menu-list", { title: "Administer menu" });
});
app.get("/admin/menu/add", (request, response) => {
  response.render("menu-add", { title: "Add menu link" });
});
app.post("/admin/menu/add/submit", async (request, response) => {
  //console.log("test msg");
  /*
  By default, form data is sent using URLencoded format whether or not it's a GET or POST form.
  weight=0&path=/&name=Home
  */
  //For a POST form, the form data is retrieved from request.body
  //For a GET form, the form data is retrieved from request.query
  //console.log(request.body);
  let newDoc = {
    weight: parseInt(request.body.weight),
    path: request.body.path,
    name: request.body.name
  };
  await addLink(newDoc);
  response.redirect("/admin/menu"); //redirect back to main admin page
});
//DELETE
app.get("/admin/menu/delete", async (request, response) => {
  //console.log(request.query.linkId);
  await deleteLink(request.query.linkId);
  response.redirect("/admin/menu");
});

// EDIT MENU
app.get("/admin/menu/edit", async (request, response) => {
  let link = await getSingleLink(request.query.id);
  response.render("menu-edit", { title: "Edit menu link", link: link });
});
// UPDATE
app.post("/admin/menu/edit/submit", async (request, response) => {
  console.log(request.body);
  let idFilter = { _id: new ObjectId(String(request.body.linkId)) };
  let link = {
    weight: parseInt(request.body.weight), 
    path: request.body.path,
    name: request.body.name
  };
  await editLink(idFilter, link);        
  response.redirect("/admin/menu");      
});


//Set up server listening
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});

//MONGODB-RELATED FUNCTIONS
async function getLinks() {
  //For the find() query, empty curly braces means select all (i.e. no filter). For the sort, we're sorting by the weight field/property in ascending order. Use -1 for descending order.
  let results = db.collection("menuLinks").find({}).sort({ weight: 1 });
  return await results.toArray(); //need toArray() to convert to JSON array
}

//Function to insert one menu link into the menuLinks collection
async function addLink(linkDocument) {
  let status = await db.collection("menuLinks").insertOne(linkDocument);
  if (status.insertedId)
    console.log("Link added successfully");
}

//Function to delete one menu link by _id
async function deleteLink(id) {
  let deleteQuery = { _id: new ObjectId(String(id)) };
  let result = await db.collection("menuLinks").deleteOne(deleteQuery);
  if (result.deletedCount === 1)
    console.log("Link deleted successfully");
  else
    console.log("Delete failed");
}

// function to edit the menu link
async function getSingleLink(id) {
  const editId = { _id: new ObjectId(String(id)) };
  const result = await db.collection("menuLinks").findOne(editId);
  return result;
}
// Update the menu
async function editLink(filter, updatedLink) {
  let result = await db.collection("menuLinks").updateOne(filter, { $set: updatedLink });
  if (result.modifiedCount === 1)
    console.log("Link updated successfully");
  else
    console.log("Update failed");
}