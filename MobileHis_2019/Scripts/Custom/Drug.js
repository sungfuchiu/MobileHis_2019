//# sourceURL=formEditor.js
//import {doAjax} from '/Scripts/Custom/ajaxencapsulation.js';
function GetFrequencyPairs(url) {
    let pairs;
    doAjax(url,
    function (result) {
        pairs= JSON.parse(result);
    });
    return pairs;
}
