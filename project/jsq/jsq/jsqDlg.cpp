
// jsqDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "jsq.h"
#include "jsqDlg.h"
#include "afxdialogex.h"
#include <stdio.h>
#include <stack>
#include <vector>
#include <string>
using namespace std;
#define Maxsize 100

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CjsqDlg 对话框




CjsqDlg::CjsqDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CjsqDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CjsqDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CjsqDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CjsqDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CjsqDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON21, &CjsqDlg::OnBnClickedButton21)
	ON_BN_CLICKED(IDC_BUTTON3, &CjsqDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON4, &CjsqDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON8, &CjsqDlg::OnBnClickedButton8)
	ON_BN_CLICKED(IDC_BUTTON12, &CjsqDlg::OnBnClickedButton12)
	ON_BN_CLICKED(IDC_BUTTON16, &CjsqDlg::OnBnClickedButton16)
	ON_BN_CLICKED(IDC_BUTTON19, &CjsqDlg::OnBnClickedButton19)
	ON_BN_CLICKED(IDC_BUTTON17, &CjsqDlg::OnBnClickedButton17)
	ON_BN_CLICKED(IDC_BUTTON5, &CjsqDlg::OnBnClickedButton5)
	ON_BN_CLICKED(IDC_BUTTON6, &CjsqDlg::OnBnClickedButton6)
	ON_BN_CLICKED(IDC_BUTTON7, &CjsqDlg::OnBnClickedButton7)
	ON_BN_CLICKED(IDC_BUTTON9, &CjsqDlg::OnBnClickedButton9)
	ON_BN_CLICKED(IDC_BUTTON10, &CjsqDlg::OnBnClickedButton10)
	ON_BN_CLICKED(IDC_BUTTON11, &CjsqDlg::OnBnClickedButton11)
	ON_BN_CLICKED(IDC_BUTTON13, &CjsqDlg::OnBnClickedButton13)
	ON_BN_CLICKED(IDC_BUTTON14, &CjsqDlg::OnBnClickedButton14)
	ON_BN_CLICKED(IDC_BUTTON15, &CjsqDlg::OnBnClickedButton15)
	ON_BN_CLICKED(IDC_BUTTON18, &CjsqDlg::OnBnClickedButton18)
	ON_BN_CLICKED(IDC_BUTTON20, &CjsqDlg::OnBnClickedButton20)
END_MESSAGE_MAP()


// CjsqDlg 消息处理程序

BOOL CjsqDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	ShowWindow(SW_RESTORE);

	// TODO: 在此添加额外的初始化代码

	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CjsqDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标
//显示。
HCURSOR CjsqDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}




int CjsqDlg::Prior(char c)
{

	if (c == '+' || c == '-')
	{
		return 1;
	}
	else if (c == '*' || c == '/')
	{
		return 2;
	}
	else
	{
		return 0;
	}
}

void CjsqDlg::trans(char exp[Maxsize])
{
	char postexp[Maxsize] = "";
	int i = 0, j = 0, n = 0;
	for (; i < cout.size(); i++)
	{

		switch (exp[i])
		{
		case '+':
		case '-':
		case '*':
		case '/':
			if (opStack.empty() || opStack.top() == '(')
			{
				opStack.push(exp[i]);
			}
			else
			{
				while (!opStack.empty() && (Prior(opStack.top()) >= Prior(exp[i])))
				{
					postexp[j] = exp[i];
					j++;
					opStack.pop();
				}
				opStack.push(exp[i]);
			}
			break;
		case '(':
			opStack.push(exp[i]);
			break;
		case ')':
			while (!opStack.empty() && opStack.top() != '(')
			{
				postexp[j] = opStack.top();
				j++;
				opStack.pop();
			}
			if (!opStack.empty() && opStack.top() == '(')
				opStack.pop();
			break;



		default:
			if ((exp[i] >= '0' && exp[i] <= '9'))
			{
				postexp[j] = exp[i];
				j++;
				while (i + 1 < cout.size() && (exp[i + 1] >= '0' && exp[i + 1] <= '9' || exp[i + 1] == '.'))
				{
					postexp[j] = exp[i + 1];
					i++;
					j++;
				}
				postexp[j] = '#';
				j++;
				n++;
			}
			break;

		}
	}
	for (; !opStack.empty();)
	{
		postexp[j] = opStack.top();
		j++;
		opStack.pop();
	}
	jisuan(postexp);
}//转换为后缀型
void CjsqDlg::jisuan(char postexp[Maxsize])
{
	double d, result, st1, st2;
	string tem;
	int i, j = 0, n = 0;
	for (i = 0; i < Maxsize; i++)
	{
		if (postexp[i] == '#')
			n++;
	}
	for (i = 0; i < cout.size() + n; i++)
	{
		if (postexp[i] != '#' && postexp[i] >= '0' && postexp[i] <= '9')
		{
			tem = postexp[i];
			if (postexp[i + 1] == '#')
			{
				d = atof(tem.c_str());
				tem = "";
				stStack.push(d);
			}
			if (postexp[i + 1] != '#')
			{
				for (j = 1; postexp[j + i] != '#'; j++)
				{
					if (postexp[j + i] == '.')
					{
						tem += postexp[j + i];
					}
					if (postexp[j + i] >= '0' && postexp[j + i] <= '9')
					{
						tem += postexp[j + i];
					}
				}
				i += j;
				tem += postexp[i];
				d = atof(tem.c_str());
				tem = "";
				stStack.push(d);
			}
		}
		if (postexp[i] == '#')
		{

		}
		if (postexp[i] == '+')
		{
			if (!stStack.empty())
			{
				st1 = stStack.top();
				stStack.pop();
			}
			if (!stStack.empty())
			{
				st2 = stStack.top();
				stStack.pop();
			}
			stStack.push(st1 + st2);
		}
		if (postexp[i] == '-')
		{
			if (!stStack.empty())
			{
				st2 = stStack.top();
				stStack.pop();
			}
			if (!stStack.empty())
			{
				st1 = stStack.top();
				stStack.pop();
			}
			stStack.push(st1 - st2);
		}
		if (postexp[i] == '*')
		{
			if (!stStack.empty())
			{
				st1 = stStack.top();
				stStack.pop();
			}
			if (!stStack.empty())
			{
				st2 = stStack.top();
				stStack.pop();
			}
			stStack.push(st1 * st2);
		}
		if (postexp[i] == '/')
		{
			if (!stStack.empty())
			{
				st2 = stStack.top();
				stStack.pop();
			}
			if (!stStack.empty())
			{
				st1 = stStack.top();
				stStack.pop();
				if (st2 == 0)
				{
					SetDlgItemText(IDC_STATIC, _T("除数不能为零！"));
				}
			}
			if (st2 != 0)
				stStack.push(st1 / st2);
		}
	}

	if (!stStack.empty())
	{
		CString StrResult;
		result = stStack.top();
		StrResult.Format("%g", result);
		SetDlgItemText(IDC_STATIC, StrResult);
	}//输出结果
}//计算
void CjsqDlg::Run(char exp[Maxsize])
{
	trans(exp);
}
void CjsqDlg::OnBnClickedButton1()
{
	SetDlgItemText(IDC_STATIC, _T(""));
}


void CjsqDlg::OnBnClickedButton2()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("("));
}


void CjsqDlg::OnBnClickedButton21()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T(")"));
}


void CjsqDlg::OnBnClickedButton3()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	a.Delete(a.GetLength() - 1);
	SetDlgItemText(IDC_STATIC, a);
}


void CjsqDlg::OnBnClickedButton4()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("/"));
}


void CjsqDlg::OnBnClickedButton8()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("*"));
}


void CjsqDlg::OnBnClickedButton12()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("-"));
}


void CjsqDlg::OnBnClickedButton16()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("+"));
}


void CjsqDlg::OnBnClickedButton19()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("."));
}


void CjsqDlg::OnBnClickedButton17()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("(-"));
}


void CjsqDlg::OnBnClickedButton5()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("7"));
}


void CjsqDlg::OnBnClickedButton6()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("8"));
}


void CjsqDlg::OnBnClickedButton7()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("9"));
}


void CjsqDlg::OnBnClickedButton9()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("4"));
}


void CjsqDlg::OnBnClickedButton10()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("5"));;
}


void CjsqDlg::OnBnClickedButton11()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("6"));
}


void CjsqDlg::OnBnClickedButton13()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("1"));
}


void CjsqDlg::OnBnClickedButton14()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("2"));
}


void CjsqDlg::OnBnClickedButton15()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("3"));
}


void CjsqDlg::OnBnClickedButton18()
{
	CString a;
	GetDlgItemText(IDC_STATIC, a);
	SetDlgItemText(IDC_STATIC, a + _T("0"));
}


void CjsqDlg::OnBnClickedButton20()
{
	CString str;
	GetDlgItemText(IDC_STATIC, str);
	strcpy_s(exp, str);
	cout = str.GetBuffer(0);




	Run(exp);

	/*CString result;
	double I=st.data[st.top];
	result.Format("%lf",I);*/
	//exp=str.GetBuffer(0);
}

