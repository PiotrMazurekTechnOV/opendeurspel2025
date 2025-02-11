const mysql = require("mysql2/promise");

async function testConnection() {
    try {
        const con = await mysql.createConnection({
            host: "localhost",
            user: "root",
            password: "root",
            database: "streetfighter",
        });
        console.log("Connection successful!");
        await con.end();
    } catch (err) {
        console.error("Connection failed:", err.message);
    }
}

testConnection();
