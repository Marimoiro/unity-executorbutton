using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.ExecutorButton;

namespace Assets.ExecutorButton.Sample
{
    class SampleModel : Model
    {

        public string GameStatus = "ゲームはまだ始まってないよ";

        [ExecutorButton]
        public void SampleExecutor()
        {
            GameStatus = "ゲームが開始したよ";
        }
    }
}
