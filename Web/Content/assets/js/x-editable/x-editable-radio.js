/**
 * The idea was taken here https://github.com/vitalets/x-editable/issues/153
 *
 * We need to remove this code in the future because this functionality ('radiolist')
 * will be in x-editable by default.
 *
 * You can use only json as a `source`:
 * $('.editable-earn-method').editable({
 *     name: 'earn_method',
 *     source: {'1': 'Yes', '0': 'No'},
 * });
 *
 */
(function ($) {
    var Radiolist = function (options) {
        this.init('radiolist', options, Radiolist.defaults);
    };
    $.fn.editableutils.inherit(Radiolist, $.fn.editabletypes.list);

    $.extend(Radiolist.prototype, {
        renderList: function () {
            var $label;
            this.$tpl.empty();
            if (!$.isArray(this.sourceData)) {
                return;
            }

            for (var i = 0; i < this.sourceData.length; i++) {
                var name = this.options.name || 'default_name';
                $label = $('<label class="radio-inline">')
                    .append($('<input>', {
                        type: 'radio',
                        name: name,
                        value: this.sourceData[i].value
                    }));
                $label.append($('<span>').text(this.sourceData[i].text));

                // Add radio buttons to template
                this.$tpl.append($label);
            }

            this.$input = this.$tpl.find('input[type="radio"]');
            this.setClass();
        },

        value2str: function (value) {
            return value;
        },

        //parse separated string
        str2value: function (str) {
            return str;
        },

        //set checked on a required radio button
        value2input: function (value) {
            this.$input.each(function (i, el) {
                var val = $(el).val()
                if (val == value) {
                    $(el).prop('checked', true);
                }
            });
        },

        input2value: function () {
            return this.$input.filter(':checked').val();
        },

        //collect text of checked boxes
        value2htmlFinal: function (value, element) {
            var checked = $.fn.editableutils.itemsByValue(value, this.sourceData);
            if (checked.length) {
                var textual_value = this.sourceData.filter(
                    function (x) {
                        if (x.value == value) return x.text
                    }
                )[0].text;
                $(element).html($.fn.editableutils.escape(textual_value));
            } else {
                $(element).empty();
            }
        },

        value2submit: function (value) {
            return value;
        },

        activate: function () {
            // Don't set focus because it looks useless for radio-buttons
        }
    });

    Radiolist.defaults = $.extend({}, $.fn.editabletypes.list.defaults, {
        /**
         @property tpl
         @default <div></div>
         **/
        tpl: '<label class="editable-radiolist input-sm"></label>',

        /**
         @property inputclass
         @type string
         @default null
         **/
        inputclass: '',

        /**
         Separator of values when reading from `data-value` attribute
 
         @property separator
         @type string
         @default ','
         **/
        separator: ',',

        name: 'defaultname'
    });

    $.fn.editabletypes.radiolist = Radiolist;

}(window.jQuery));