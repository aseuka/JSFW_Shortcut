# JSFW_Shortcut
백업용 바탕화면 바로가기

목적 : 매일 매일 수정하는 파일을 백업하면서 관리해야 할때 사용하려고 만들었었다. <br />
  기존에 svn같은 형상관리 툴에 문서파일을 넣지 않고, 파일 복사로 관리하던 때 만들었다.<br />
 
기능 : 1일 처음 열릴때 백업을 한다. 계속 열어도 그날은 백업하지 않고 열린다.<br />
      이때 Ctrl + 실행하면 해당 시간으로 백업을 해준다. <br />

- 테스트용 파일<br />
![image](https://user-images.githubusercontent.com/116536524/197980962-098854da-be37-427f-bf7f-28f306aaa9df.png)

- 프로그램을 실행하면<br />
![image](https://user-images.githubusercontent.com/116536524/197981039-1462dadc-e575-4781-950e-8f4f62f6020b.png)

:: 위 프로그램에 test01.txt를 드랍하면 바탕화면에 바로가기 아이콘이 생성된다.<br />
![image](https://user-images.githubusercontent.com/116536524/197981244-95378657-0c08-45ec-a6b9-227d2e57b72e.png)
<br />
<br />

```diff
+ 바탕화면 test01 바로가기를 더블클릭하여 실행하면
```
![image](https://user-images.githubusercontent.com/116536524/197981500-f26a7bf1-9426-4a58-835f-a3ff3cd6b792.png)
![image](https://user-images.githubusercontent.com/116536524/197981555-6bcfb11d-f96a-4d03-97a7-1fa28442f489.png)<br />
:: 파일을 백업하고 -> 메모장(.txt기본프로그램)으로 열어준다.<br />
<br />

```diff
+ 바탕화면 test01 바로가기를 Ctrl + 더블클릭하여 실행하면
```
![image](https://user-images.githubusercontent.com/116536524/197981862-ddc4377b-263b-4698-996d-5ba89b0a7a48.png)<br />
:: 열린시간에 백업<br />



