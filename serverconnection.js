//4. Create

//Endpoint to get a single user by id
app.get('/:id', function (req, res) {
      var user = users["user" + req.params.id]
      console.log(user);
      res.end(JSON.stringify(user));
    });