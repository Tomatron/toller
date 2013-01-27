#pragma strict
#pragma implicit
#pragma downcast

@script AddComponentMenu("Library/Messenger")

/*
* Script to manage updating components when certain game events happen - for 
* instance when cars are spawned, deleted, etc
*/
var listeners:Hashtable = new Hashtable();

// spew debug info to console for each message
var debug:boolean = false;

static var instance:Messenger;
static var use:Messenger;

function Awake()
{
	// make the instance available if one isn't already
	if(instance == null)
	{
		instance = this;
		use = this;
	}
	else
	{
		Destroy(gameObject);
	}
	
	DontDestroyOnLoad(this);
}

/**
* Adds a listener for a particular type of message
*/
function Listen(listenerType:String, go:GameObject)
{	
	// if there's no array for this tracking category, make a new one
	if(listeners[listenerType] == null)
	{
		listeners[listenerType] = new ArrayList();
	}
	
	var list:ArrayList = listeners[listenerType];
	
	// only add to the array if it isn't already being tracked
	if(!list.Contains(go))
	{
		list.Add(go);
	}
}

/**
* Register implicitly with this instead of gameObject
*/
function Listen(listenerType:String, component:Component)
{
	Listen(listenerType, component.gameObject);
}

/**
* Removes a listener for the specified type of message
*/
function StopListen(listenerType:String, go:GameObject)
{
	var list:ArrayList = listeners[listenerType];
	
	if(list != null)
	{
		list.Remove(go);
	}
}

/**
* Sends a message (calls the function denoted by methodName using value value) 
* to all registered listeners for the given message type
*/
function Send(msg:Message)
{		
	// get our list (will be null if unknown type or no listeners registered)
	var list:ArrayList = listeners[msg.listenerType];	
	
	if(list)
	{
		for(var i:int = 0; i < list.Count; i++)
		{
			var listener:GameObject = list[i];
			
			if(listener)
				listener.SendMessage(msg.functionName, msg, SendMessageOptions.DontRequireReceiver);
			else
			{
				// scrub nulls
				list.RemoveAt(i);
				i--;
			}
		}
	}
	
	// show the message in the console?
	if(debug)
	{
		// get our type and all of our public fields
		var type:System.Type = typeof(msg);
		var fis:System.Reflection.FieldInfo[] = type.GetFields();
		
		// loop all of our fields
		var data:String = "";
		for(var fi:System.Reflection.FieldInfo in fis)
		{
			var value:Object = fi.GetValue(msg) == null ? "NULL" : fi.GetValue(msg);
			data += String.Format("{0}: {1}\n", fi.Name, value.ToString());
		}
		
		// build up a list of recipients
		var sentTo:String = "";
		if(list)
		{
			for(var go:GameObject in list)
				sentTo += go.name + ", ";
				
			sentTo = sentTo.Substring(0, sentTo.Length - 2);
		}
				
		Debug.Log(
			String.Format(
				"MSG {0} ({1}) sent to {2} objects\n{3}\n{4}"
				,msg.functionName
				,msg.listenerType
				,list ? list.Count : 0
				,sentTo
				,data
				)
			);
	}
}