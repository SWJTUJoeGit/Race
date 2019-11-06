var express = require('express');
var router = express.Router();
//关联主程序
var GuideIconlist = require('../GuideIcon/GuideIconList.js');

/* GET home page. */
//进入主页面信息
router.get('/', function(req, res, next) {
  res.render('index', { title: '交通标识数据库'});
});

//增
router.get('/GuideIconAdd',function(req,res,next){
	GuideIconlist.GuideIconadd(req,res,next);
});

//删
router.get('/GuideIconDel',function(req,res,next){
	GuideIconlist.GuideIcondelete(req,res,next);
});
//改
router.get('/GuideIconUpdate',function(req,res,next){
	GuideIconlist.GuideIconupdate(req,res,next);
});
//查
router.get('/GuideIconAll',function(req,res,next){
	GuideIconlist.GuideIconAll(req,res,next);
});
router.get('/GuideIconById',function(req,res,next){
	GuideIconlist.GuideIconById(req,res,next);
});

module.exports = router;
