#pragma strict

function Start () {
	Messenger.instance.Listen("testmessage", this);
}

function _Test(msg:MessageTest)
{
	Debug.Log("TestMessage!!!");
}

function Update () {

	if(Input.anyKeyDown)
	{
		new MessageTest();
	}
}