using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FSharp.Core;

namespace ABCEditor
{
    public partial class FormABCEditor : Form
    {
        /// <summary>
        /// オブジェクトを使ったバージョン
        /// </summary>
        public FormABCEditor()
        {
            InitializeComponent();
            init();
        }

        private ABCEditorFSharp.ABCEditor abc_editor_fs;

        private void init()
        {
            //FSharpFunc<string, Unit> f_set_text = FuncConvert.ToFSharpFunc((Action<string>)SetTextProc);
            FSharpFunc<string, Unit> f_set_text = FuncConvert.ToFSharpFunc(new Action<string>(SetTextProc));
            //FSharpFunc<string, Unit> f_set_text = FuncConvert.ToFSharpFunc(delegate(string text) { textBoxABC.Text = text; });
            Action close_action = new Action(CloseProc);
            //Action<Unit> close_action2 = new Action<Unit>(CloseProc);
            //Converter<Unit, Unit> close_action_2 = new Converter<Unit, Unit>(close_action);
            FSharpFunc<Unit, Unit> f_close = FuncConvert.ToFSharpFunc(close_action);
            Action<int> close_action_1 = new Action<int>(CloseProc1);
            FSharpFunc<int, Unit> f_close_1 = FuncConvert.ToFSharpFunc(close_action_1);
            //FSharpFunc<Unit, Unit> f_close = FuncConvert.ToFSharpFunc(close_action);
            //FSharpFunc<Unit, Unit> f_close = (FSharpFunc<Unit, Unit>)close_action;
            //FSharpFunc<Unit, Unit> f_close = FuncConvert.ToFSharpFunc<Unit>(new Action<Unit>(new Action(CloseProc)));
            abc_editor_fs = new ABCEditorFSharp.ABCEditor(f_set_text, f_close);
            //var f_close = (FSharpFunc<Unit, Unit>)CloseProc;
            //var f = new Converter<string, Unit>(SetTextProc);
            //abc_editor_fs = new ABCEditorFSharp.ABCEditor((FSharpFunc<string, Unit>)delegate(string text) { textBoxABC.Text = text; }, (FSharpFunc<Unit, Unit>)delegate() { Close(); });
            //abc_editor_fs = new ABCEditorFSharp.ABCEditor((FSharpFunc<string, Unit>)SetTextProc, (FSharpFunc<Unit, Unit>)CloseProc);
        }

        public void SetTextProc(string text)
        {
            textBoxABC.Text = text;
        }

        public void CloseProc()
        {
            Close();
        }

        public void CloseProc1(int x)
        {
            Close();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            abc_editor_fs.ButtonA_Click_Proc();
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            abc_editor_fs.ButtonB_Click_Proc();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            abc_editor_fs.ButtonC_Click_Proc();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            abc_editor_fs.ButtonExit_Click_Proc();
        }
    }
}
