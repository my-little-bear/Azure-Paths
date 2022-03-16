$ACR_NAME="myacrtemp"
$ACR_REIGSTRY_ID=$(az acr show --name $ACR_NAME --query id --output table)

SP_NAME='acr-service-principal'
SP_PASSWD=$(az ad sp create-for-rbac) `
    --name http://$ACR_NAME-pull `
    --scopes $ACR_REIGSTRY_ID `
    --role $ACR_NAME-pull `
    --query password `
    --output tsv)

    

    
