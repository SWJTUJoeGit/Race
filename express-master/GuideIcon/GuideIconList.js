//实现与mysql交互
var mysql=require('mysql');
var $conf=require('../conf/database.js');
var $util=require('../util/util.js');
var $sql=require('./GuideIconSql.js');
//使用连接池
var pool  = mysql.createPool($util.extend({}, $conf.mysql));

// 向前台返回JSON方法的简单封装
var jsonWrite = function (res, ret) {
	if(typeof ret === 'undefined') {
		res.json({
			code:'1',
			msg: "修改失败"+ret
		});
	} else {
		res.json(ret);
	}
};

module.exports = {
	//增加标识
	GuideIconadd: function (req, res, next) {
		pool.getConnection(function(err, connection) {
			// 获取前台页面传过来的参数
			var param = req.query || req.params;
 			
			// 建立连接，向表中插入值
			
			connection.query($sql.guideIconinsert, [param.id, param.code,param.name,param.datetime, param.location,param.cordinate_x,param.cordinate_y], function(err, result) {
				if(result) {
					result = {
						code: 200,
						msg:'增加成功'
					};    
					
				}
				
 
				// 以json形式，把操作结果返回给前台页面
				jsonWrite(res, result);
 
				// 释放连接 
				connection.release();
			});
		});
	},
    GuideIcondelete: function (req, res, next) {
		// delete by Id
		
		try{
        pool.getConnection(function(err, connection) {
			var id =+req.query.id;
			
            connection.query($sql.GuideIcondelete, id, function(err, result) {
				if(!err) {
                    result = {
                        code: 200,
                        msg:'删除成功'
                    };
                }
				else {
					
					result ={code:400,
					msg:err};
					//console.log('DELETE affectedRows',result.affectedRows);
				}
				
                jsonWrite(res, result);
                connection.release();
            });
		});
		}catch(err){
			console.log(err);
		}
    },
    GuideIconupdate: function (req, res, next) {
        // update by id
        
        pool.getConnection(function(err, connection) {
			// 获取前台页面传过来的参数
			var param = req.query || req.params;
 			
			// 建立连接，向表中插入值
			
			connection.query($sql.guideIconupdate, [param.id, param.code,param.name,param.datetime, param.location,param.cordinate_x,param.cordinate_y], function(err, result) {
				if(result.affectedRows>0) {
					result = {
						code: 200,
						msg:'修改成功'
					};    
				}
				else {
					result ={code:400,
					msg:'修改失败'};
					console.log('MODIFY affectedRows',result.affectedRows);
                }

				// 以json形式，把操作结果返回给前台页面
				jsonWrite(res, result);
 
				// 释放连接 
				connection.release();
			});
		});
    },
    	//得到所有道路标识信息 在路由routes调用本方法，这个方法调用sql语句 ，并返回相应结果jsonwrite
    GuideIconAll: function (req, res, next) {
        pool.getConnection(function(err, connection) {
            connection.query($sql.guideIconAll, function(err, result) {
                jsonWrite(res, result);
                connection.release();
            });
        });
    },

    GuideIconById: function (req, res, next) {
        var id = +req.query.id; // 为了拼凑正确的sql语句，这里要转下整数
        pool.getConnection(function(err, connection) {
            connection.query($sql.guideIconById, id, function(err, result) {
                jsonWrite(res, result);
                connection.release();

            });
        });
    },
};