package com.example.soap_services;


import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.os.Bundle;
import android.os.StrictMode;
import android.app.Activity;
import android.view.Menu;
import android.widget.TextView;

public class MainActivity extends Activity {

	private static String SOAP_ACTION = "http://tempuri.org/GetCity";

	private static String NAMESPACE = "http://tempuri.org/";
	private static String METHOD_NAME = "GetCity";

	private static String URL = "http://kc-sce-cs551.kc.umkc.edu/aspnet_client/Group4/Address1/WebService.asmx";

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder()
				.permitAll().build();

		StrictMode.setThreadPolicy(policy);

		TextView data = (TextView) findViewById(R.id.data);
		SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);
		request.addProperty("ZipCode", "64112");

		SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
				SoapEnvelope.VER11);
		envelope.dotNet = true;
		envelope.setOutputSoapObject(request);
		
		// Needed to make the internet call
		HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
		try {
			// this is the actual part that will call the webservice
			androidHttpTransport.call(SOAP_ACTION, envelope);
			SoapPrimitive resultSet = (SoapPrimitive) envelope.getResponse();
			String what = resultSet.toString();
			System.out.println(what);
			data.setText(what);
		} catch (Exception e) {
			e.printStackTrace();
		}

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

}
