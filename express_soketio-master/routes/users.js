var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  var file_nm = 'File Name';
  var file_orign_nm = 'File Orignal Name';
  var file_path = 'File Path';
  var file_ext = 'File Ext';
  var file_array = [file_nm, file_orign_nm, file_path, file_ext];
  var file_json = JSON.stringify(file_array);
  res.io.emit("socketToMe", file_json);
  res.send('respond with a resource');
});

module.exports = router;
