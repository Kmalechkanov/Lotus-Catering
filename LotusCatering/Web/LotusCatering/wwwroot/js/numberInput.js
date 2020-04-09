function incrementValue(e) {
    e.preventDefault();
    var fieldName = $(e.target).data('field');
    var parent = $(e.target).closest('div');
    var currentVal = parseInt(parent.find('input[name=' + fieldName + ']').val(), 10);
    console.log(currentVal);
    if (!isNaN(currentVal) && currentVal <= 290) {
        parent.find('input[name=' + fieldName + ']').val(currentVal + 10);
    } else {
        parent.find('input[name=' + fieldName + ']').val(10);
    }
}

function decrementValue(e) {
    e.preventDefault();
    var fieldName = $(e.target).data('field');
    var parent = $(e.target).closest('div');
    var currentVal = parseInt(parent.find('input[name=' + fieldName + ']').val(), 10);
    console.log(currentVal);
    if (!isNaN(currentVal) && currentVal > 10) {
        parent.find('input[name=' + fieldName + ']').val(currentVal - 10);
    } else {
        parent.find('input[name=' + fieldName + ']').val(10);
    }
}

$('.input-group').on('click', '.button-plus', function (e) {
    incrementValue(e);
});

$('.input-group').on('click', '.button-minus', function (e) {
    decrementValue(e);
});