module.exports = async function (context, documents) {
    if (!!documents && documents.length > 0) {
        context.log(`Documents: ${documents.length}`);
        context.log(`###########Documents########## \n ${documents}`);
    }
}
