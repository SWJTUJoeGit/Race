var express = require('express');
var router = express.Router();
var mysql = require('mysql');
var dateTime = require('node-datetime');

var conn = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '123456',
    port: 3007,
    database: 'Traffic_sign_GeoDatabase'
});

conn.connect();

router.get('/', function (req, res, next) {

    res.render('test');
});

/* GET users listing. */
router.post('/setTest', function(req, res, next) {
    var title = req.body.title;
    var content = req.body.content;
    var dt = dateTime.create();
    var create_date = dt.format('Y-m-d H:M:S');
    var data_arr = {};
    data_arr["title"] = title;
    data_arr["content"] = content;
    data_arr["create_date"] = create_date;
    var json_obj = JSON.stringify(data_arr);
    conn.query("INSERT INTO test_board (title, content, create_date) VALUES ('"+title+"', '"+content+"', '"+create_date+"')", function (err, rows, fields) {
       if(!err){
           console.log("Insert data : " + rows);
           res.io.emit("socketToMe", json_obj);
           res.send({result : "SUCCESS"});
       }
    });
});

module.exports = router;
