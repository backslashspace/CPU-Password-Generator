using System;

internal static partial class Settings
{
    private static void SetDefaultSelection(Boolean cleanBeforeSet)
    {
        if (cleanBeforeSet)
        {
            for (Int32 i = 0; i < 256; ++i)
            {
                CheckBoxes[i].Checked = false;
            }

            _persistentSettings!.Checked = false;
            _exactLength!.Checked = false;

            _encoding_raw!.Checked = true;
            _encoding_base64_trim!.Checked = true;
        }

        CheckBoxes[' '].Checked = true;
        CheckBoxes['!'].Checked = true;
        CheckBoxes['#'].Checked = true;
        CheckBoxes['$'].Checked = true;
        CheckBoxes['('].Checked = true;
        CheckBoxes[')'].Checked = true;
        CheckBoxes['+'].Checked = true;
        CheckBoxes['-'].Checked = true;
        CheckBoxes['.'].Checked = true;
        CheckBoxes['0'].Checked = true;
        CheckBoxes['1'].Checked = true;
        CheckBoxes['2'].Checked = true;
        CheckBoxes['3'].Checked = true;
        CheckBoxes['4'].Checked = true;
        CheckBoxes['5'].Checked = true;
        CheckBoxes['6'].Checked = true;
        CheckBoxes['7'].Checked = true;
        CheckBoxes['8'].Checked = true;
        CheckBoxes['9'].Checked = true;
        CheckBoxes['='].Checked = true;
        CheckBoxes['@'].Checked = true;

        for (Int32 i = 'A'; i < 'Z' + 1; ++i)
        {
            CheckBoxes[i].Checked = true;
        }

        CheckBoxes['['].Checked = true;
        CheckBoxes[']'].Checked = true;
        CheckBoxes['_'].Checked = true;

        for (Int32 i = 'a'; i < 'z' + 1; ++i)
        {
            CheckBoxes[i].Checked = true;
        }

        CheckBoxes['{'].Checked = true;
        CheckBoxes['}'].Checked = true;
        CheckBoxes['~'].Checked = true;
    }
}