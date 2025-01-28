const express = require("express");
const app = express();
const mysql = require("mysql2/promise");
const bodyParser = require("body-parser");
const cors = require("cors");
require('dotenv').config()
var corsOptions = {
  origin: "http://localhost:8081"
};

app.use(cors(corsOptions));
app.use(express.json());

// Middleware
app.use(cors());
app.use(bodyParser.json());

// Database connection 
async function connect() {
    try {
        return await mysql.createConnection({
            host: process.env.HOST,
            user: process.env.USER,
            password: process.env.PASSWORD,
            database: process.env.DB,
        });
    } catch (err) {
        console.error("Error connecting to the database:", err.message);
        throw err;
    }
}
//UPDATES
app.post("/user/update", async (req, res) => {
  try {
      const { name, age, email, gsm_number, code, consent } = req.body;

      if (!name || !age || !consent) {
          return res.status(400).json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `
         
      `;
      await con.execute(query, [name, age, email, gsm_number, code, consent, code]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
    res.json(err)
  }
});

app.post("/location/update", async (req, res)=>{
  try {
    const { number, name} = req.body;
    if(!number || !name) {
      return res.status(400).json({error: "All fields are required."});
    }
    const con = await connect(); 
      const query = `
         
      `;
      await con.execute(query, [number, name]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
    res.json(err)
  }}
);

app.get("/test", async (req, res)=>{
  res.send("dit is een test")
})

// Start the server
const PORT = process.env.PORT || 8081;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});

