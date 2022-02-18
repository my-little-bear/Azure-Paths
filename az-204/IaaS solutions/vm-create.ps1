Connect-AzAccount 
Set-AzContext -Subscription '<sub-id>'

New-AzResourceGroup -Name 'mydemo' -Location 'CentralUS'

$username = 'demoadmin'
$password = ConvertTo-SecureString '#demoadmin100' -AsPlainText -Force
$WinCreds = New-Object Systen.Management.Automation.PSCredential($username, $password)

New-AzVM `
    -ResourceGroupName "mydemo" `
    -Name "mydemo-win" `
    -Image "Win2019Datacenter" `
    -Credential $WinCreds `
    -OpenPorts 3389

New-AzResourceGroupDeployment `
    -TemplateParameterFile "<parameter-json>"`
    -TemplateFile "<template.json>"
     