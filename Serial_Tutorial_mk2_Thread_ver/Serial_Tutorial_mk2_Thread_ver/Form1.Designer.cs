namespace Serial_Tutorial_mk2_Thread_ver
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.terminate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.set_Port = new System.Windows.Forms.ComboBox();
            this.output_guide = new System.Windows.Forms.Label();
            this.measurement_result = new System.Windows.Forms.DataGridView();
            this.Stop = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.measurement_result)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "현재상태 : 연결안됨";
            // 
            // terminate
            // 
            this.terminate.Location = new System.Drawing.Point(13, 199);
            this.terminate.Name = "terminate";
            this.terminate.Size = new System.Drawing.Size(116, 26);
            this.terminate.TabIndex = 18;
            this.terminate.Text = "리셋";
            this.terminate.UseVisualStyleBackColor = true;
            this.terminate.Click += new System.EventHandler(this.terminate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "포트 선택";
            // 
            // set_Port
            // 
            this.set_Port.AccessibleName = "";
            this.set_Port.FormattingEnabled = true;
            this.set_Port.Location = new System.Drawing.Point(13, 30);
            this.set_Port.Name = "set_Port";
            this.set_Port.Size = new System.Drawing.Size(126, 20);
            this.set_Port.TabIndex = 16;
            // 
            // output_guide
            // 
            this.output_guide.AutoSize = true;
            this.output_guide.Location = new System.Drawing.Point(180, 15);
            this.output_guide.Name = "output_guide";
            this.output_guide.Size = new System.Drawing.Size(85, 12);
            this.output_guide.TabIndex = 15;
            this.output_guide.Text = "저항 측정 결과";
            // 
            // measurement_result
            // 
            this.measurement_result.AllowUserToOrderColumns = true;
            this.measurement_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.measurement_result.Location = new System.Drawing.Point(182, 30);
            this.measurement_result.Name = "measurement_result";
            this.measurement_result.RowTemplate.Height = 23;
            this.measurement_result.Size = new System.Drawing.Size(254, 220);
            this.measurement_result.TabIndex = 14;
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(13, 167);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(116, 26);
            this.Stop.TabIndex = 13;
            this.Stop.Text = "정지";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(13, 135);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(116, 26);
            this.Start.TabIndex = 12;
            this.Start.Text = "시작";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.terminate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.set_Port);
            this.Controls.Add(this.output_guide);
            this.Controls.Add(this.measurement_result);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.measurement_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button terminate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox set_Port;
        private System.Windows.Forms.Label output_guide;
        private System.Windows.Forms.DataGridView measurement_result;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Start;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

