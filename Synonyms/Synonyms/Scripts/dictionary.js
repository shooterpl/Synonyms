var url = 'api/SynonymDtoes';

$(document).ready(function () {
    $.getJSON(url)
        .done(function (data) {
            $.each(data, function (key, item) {
                for (i = 0; i < item.Synonyms.length ; i++) {
                    $('.synonym-list').after("<span class='list'>" + item.Synonyms[i] + "</span>");
                }
                $('.synonym-list').after("<div class='term'>" + item.Term + "</div>");
            });
        });
});

function adding() {
    data = {
        Type: "SynonymDtoViewModel",
        Term: $('#tbTerm').val().toString(),
        Synonyms: $('#tbSynList').val().toString()
    };
    $.post(url, data);
    window.location.reload();
}



