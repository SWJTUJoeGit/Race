var GuideIcon={
	//增
	guideIconinsert:'INSERT INTO guideinfo (id,code,name,datetime,location,cordinate_x,cordinate_y) VALUES(0,?,?,?,?,?,?)',
	
	//删
	guideIcondelete: 'delete * from guideinfo where id=?',
	//改
	guideIconupdate:'UPDATE guideinfo SET code=?,name=?,datetime=?,location=?,cordinate_x=?,cordinate_y=? WHERE id=?',
    //查
    guideIconAll: 'SELECT * from guideinfo',
    guideIconById: 'select * from guideinfo where id=?'
}

module.exports=GuideIcon;