function DisableAllControlsById(containerId)
{
    $('#' + containerId).find("input:not([type = 'hidden']), button, submit, textarea, select").attr("disabled", "disabled");
   // $('#' + containerId).find("input[type='hidden']").attr("readonly", "readonly");

}
function HideAllControlsById(containerId)
{
    $('#' + containerId).find("input, button, submit, textarea, select").attr("disabled", "disabled");
}