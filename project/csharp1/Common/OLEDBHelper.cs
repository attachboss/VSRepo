using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransGPSPT2020
{
    class OLEDBHelper
    {
        //定义全局变量
        /// <summary>
        /// 用于保存当前类的连接类
        /// </summary>
        private OleDbConnection m_oConn = null;
        private const string CON_strDataBase = "Data Source";
        private const string CON_strConnTimeOut = "Connect Timeout = 2";
        private string m_strConnection = "";  //连接的字符串；
        private string m_strDBFileName = "";  //保存连接的文件名称；

        /// <summary>
        /// 全局连接对象
        /// </summary>
        public OleDbConnection Connection
        {
            get
            {
                return m_oConn;
            }
        }

        /// <summary>
        /// 全局连接字符串
        /// </summary>
        public string StrConnection
        {
            get
            {
                return m_strConnection;
            }
        }

        private OleDbDataAdapter m_Adapter = null;

        /// <summary>
        /// 全局数据编辑对象
        /// </summary>
        public OleDbDataAdapter Adapter
        {
            get
            {
                return m_Adapter;
            }
        }

        /// <summary>
        /// 数据库文件名称
        /// </summary>
        public string StrDBFileName
        {
            get
            {
                return m_strDBFileName;
            }
            set
            {
                m_strDBFileName = value;
            }
        }



        /// <summary>
        /// 根据文件名称，构建连接字符串；
        /// </summary>
        /// <param name="strDBFileName"></param>
        public void BuildStrConnection(string strDBFileName)
        {
            string strConn = "Provider = ";
            switch (strDBFileName.Substring(strDBFileName.LastIndexOf('.') + 1).ToLower())
            {
                case "mdb":     // 2000, 2003
                    strConn += "Microsoft.Jet.OleDb.4.0;";
                    break;

                case "accdb":   // 2007
                    strConn += "Microsoft.ACE.OLEDB.12.0;";
                    break;

                default:
                    throw (new Exception("Unknown Access Version."));
            }
            strConn += CON_strDataBase + " = " + strDBFileName;
            m_strConnection = strConn;         //保存连接字符串；
            m_strDBFileName = strDBFileName;   //保存连接数据库文件名称；

        }

        /// <summary>
        /// 判断数据库文件是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsDBFileExist()
        {
            if (File.Exists(m_strDBFileName))
            {//如果已经存在数据库文件
                return true;
            }
            else
            {//否则创建数据库
                return false;
            }

        }

        /// <summary>
        /// 按照全局连接字符串建立一个新的连接类对象。
        /// </summary>
        /// <param name="strDataBase"></param>
        public void InitConn()
        {
            m_oConn = new OleDbConnection(m_strConnection);
        }

        /// <summary>
        /// 打开一个连接
        /// </summary>
        public void Open()
        {
            if (this.m_oConn != null)
            {
                this.m_oConn.Open();
            }
            else
            {
                throw (new Exception("Connection Class Instance has not Create."));
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (this.m_oConn != null && this.m_oConn.State == System.Data.ConnectionState.Open)
            {
                this.m_oConn.Close();
            }
        }


        /// <summary>
        /// 按表名删除数据表
        /// </summary>
        /// <param name="szTable">数据表名</param>
        public void Delete_Table(string szTable)
        {
            DialogResult r = MessageBox.Show("是否删除当前表！", "删除当前表！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int ss = (int)r;
            if (ss == 6) // 按动"确定"按钮
            {
                try
                {
                    //连接到一个数据库
                    string szCommand = "drop table " + szTable;
                    //OleDbCommand DeleteTable = new OleDbCommand(szCommand, m_oConn);
                    //DeleteTable.ExecuteNonQuery();
                    RunNoQuery(szCommand);
                }
                catch (Exception ed)
                {
                    MessageBox.Show("删除表错误信息： " + ed.Message, "错误！");
                }
            }
        }

        /// <summary>
        /// 获得数据表中记录数量
        /// </summary>
        /// <param name="szTable">数据表名</param>
        /// <returns>数据表中记录数量</returns>
        public int GetTableRecsCount(string szTable)
        {
            int izcnt = -1;
            OleDbCommand thisCommand = new OleDbCommand("select   count(*)   as   num   From " + szTable, m_oConn);
            try
            {
                izcnt = int.Parse(thisCommand.ExecuteScalar().ToString());
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return izcnt;

        }

        /// <summary>
        /// 根据命令字符串创建一个命令对象
        /// </summary>
        /// <param name="strCmd">SQL命令</param>
        /// <returns>命令对象</returns>
        private OleDbCommand GetCmd(string strCmd)
        {
            return new OleDbCommand(strCmd, (OleDbConnection)m_oConn);
        }

        /// <summary>
        /// 执行一个没有返回的查询
        /// </summary>
        /// <param name="strCmd">SQL命令</param>
        /// <returns>影响的记录数</returns>
        public int RunNoQuery(string strCmd)
        {
            int iRet = 0;
            try
            {
                OleDbCommand oCmd = GetCmd(strCmd);
                if (oCmd != null)
                {
                    iRet = oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            return iRet;
        }

        /// <summary>
        /// 根据命令和全局连接变量创建一个新的数据编辑对象（采用连接数据库的方式）
        /// </summary>
        /// <param name="selectCommand">命令字符串</param>
        /// <returns>数据编辑对象</returns>
        public OleDbDataAdapter GetAdp(string selectCommand)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, m_oConn);
            return adapter;
        }

        /// <summary>
        /// 创建一个数据编辑对象
        /// </summary>
        public OleDbDataAdapter DbAdp
        {
            get { return new OleDbDataAdapter(); }
        }

        /// <summary>
        /// 判断当前类是否已经连接数据库
        /// </summary>
        /// <returns>正确连接，则返回True</returns>
        public bool IsConnected()
        {
            bool bRet = true;
            try
            {
                if (this.m_oConn.State != System.Data.ConnectionState.Open)
                {
                    this.m_oConn.Open();
                }
                bRet = this.m_oConn.State == System.Data.ConnectionState.Open;
            }
            catch
            {
                bRet = false;
            }
            return bRet;
        }

        /// <summary>
        /// 以数据表格形式返回查询结果
        /// </summary>
        /// <param name="strCmd">查询的命令</param>
        /// <returns>返回的数据表</returns>
        public DataTable RunQuery(string strCmd)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = DbAdp;
            adp.SelectCommand = this.GetCmd(strCmd);
            OleDbCommandBuilder bldr = new OleDbCommandBuilder(adp);

            adp.Fill(dt);
            m_Adapter = adp;
            return dt;
        }

        /// <summary>
        /// 判断数据库中是否已经存在给定名称表格
        /// </summary>
        /// <param name="strCon">数据库连接字</param>
        /// <param name="szTable">欲查询的表格名称</param>
        /// <returns>True已经存在， False不存在</returns>
        public bool IsTableExist(string szTable) //DataTable GetTables(string strCon) //OleDbConnection conn)
        {
            bool brt = false;
            try
            {
                DataTable schemaTable = m_oConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                foreach (DataRow dr in schemaTable.Rows)
                {
                    //MessageBox.Show((String)dr["TABLE_NAME"]);
                    if ((String)dr["TABLE_NAME"] == szTable)
                    {
                        brt = true;
                        break;
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                brt = false;
            }
            return brt; //schemaTable;
        }


        public DataTable GetColumns(string strTable)
        {
            return ((OleDbConnection)m_oConn).GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, strTable, null });
        }

        /// <summary>
        /// 在指定表中添加一条记录。连接方式，直接影响数据库
        /// </summary>
        /// <param name="szTable">表名</param>
        /// <param name="szValue">添加的数据，按SQL语法</param>
        /// <returns>影响了几条数据</returns>
        public int InsertDBData(string szTable, string szValue)
        {
            //"INSERT INTO EMPLOYEES VALUES ('Smith','Pocahontas','1976-04-06', 'Los Angles',12,100000)";
            //('n','赵六','女', '29','610017')
            //"INSERT INTO MyTable2 Values ('3','赵六','女', '29','610017')"
            string szCmd = "INSERT INTO " + szTable + " Values " + szValue;
            return this.RunNoQuery(szCmd);
        }
    }
}
