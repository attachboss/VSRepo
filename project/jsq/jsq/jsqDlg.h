                                                                                    
// jsqDlg.h : ͷ�ļ�
//

#pragma once
#include <stack>
#include <string>
using namespace std;

#define Maxsize 100


// CjsqDlg �Ի���
class CjsqDlg : public CDialogEx
{
// ����
public:
	
	CjsqDlg(CWnd* pParent = NULL);	// ��׼���캯��
	void getformat(char );
	int Prior(char c);	
	void trans(char exp[Maxsize]);
	void jisuan(char postexp[Maxsize]);
	void Run(char exp[Maxsize]);
private:
	double result;
	CString str;
	string cout; 
	char exp[Maxsize];
	char postexp[Maxsize];
	stack<char> opStack;
	stack<double> stStack;
	stack<char> jzStack;
// �Ի�������
	enum { IDD = IDD_JSQ_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��
	
// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton21();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton8();
	afx_msg void OnBnClickedButton12();
	afx_msg void OnBnClickedButton16();
	afx_msg void OnBnClickedButton19();
	afx_msg void OnBnClickedButton17();
	afx_msg void OnBnClickedButton5();
	afx_msg void OnBnClickedButton6();
	afx_msg void OnBnClickedButton7();
	afx_msg void OnBnClickedButton9();
	afx_msg void OnBnClickedButton10();
	afx_msg void OnBnClickedButton11();
	afx_msg void OnBnClickedButton13();
	afx_msg void OnBnClickedButton14();
	afx_msg void OnBnClickedButton15();
	afx_msg void OnBnClickedButton18();
	afx_msg void OnBnClickedButton20();
	afx_msg void OnBnClickedButton22();
	afx_msg void OnBnClickedButton23();
};
