module.exports = async function (context, req, inputDocument) {
    context.log('JavaScript HTTP trigger function processed a request.');
    console.log(inputDocument);
    if(!inputDocument){
        let logMessage = `ToDo item ${req.query.id} not found.`;
        context.log(logMessage);
        context.res = {
            status: 404,
            body: logMessage
        };

        context.bindings.outputQueueItem = logMessage;
    }else{
        context.log(`Found ToDo item, description= ${inputDocument.desc}`);
        context.res = {
            body: inputDocument.desc
        }
    }
}