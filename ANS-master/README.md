# ANS [Azure-Node-Socket]

Basic example of a Azure web app that can be updated in realtime w/Postman API data using Node.js & Socket.io

### Run
1. ` node index.js `
2. Navigate to "localhost:8080" in a web browser
3. Use Postman to send an HTTP POST request to "localhost:8080/sms" with a "body" parameter in the x-www-form-urlencoded format. Make sure the header "Content-Type" is "application/x-www-form-urlencoded"
4. Upload to Azure `az webapp up -n <app_name>` 
