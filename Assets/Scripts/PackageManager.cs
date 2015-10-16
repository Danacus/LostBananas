using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    /*
    private WWW www;
    private bool zipready;
    private byte[] data;
    public string path;
    public bool android;
    private WebClient wb = new WebClient();
    private bool unZip;

    private void Start()
    {
        DonwloadPackage("http://dirkvanoverloop.be/LostBananas/testpackage.zip");
    }

    private void DonwloadPackage(string packageUrl)
    {

        StartDownload(packageUrl);

    }

    public void StartDownload(string url)
    {

        if (!android)
        {
            Directory.CreateDirectory(Application.dataPath + "/Packages");
            wb.DownloadFileAsync(new Uri(url), Application.dataPath + "/Packages/package.zip");
            Debug.Log("Download started: " + url + " @UnityEditor");
            wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wb_DownloadProgressChanged);
            wb.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wb_DownloadFileCompleted);

        }

        if (android)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Packages");
            wb.DownloadFileAsync(new Uri(url), Application.persistentDataPath + "/Packages/package.zip");
            Debug.Log("Download started: " + url + " @UnityAndroid");
            wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wb_DownloadProgressChanged);
            wb.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wb_DownloadFileCompleted);
        }

    }

    private void wb_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        //when the downloads are completed clean the webclinet called wb
        wb.Dispose();
        Debug.Log("Download Completed!");
        //run the function launchAndQuit()
        //launchAndQuit();
        unZip = true;
    }

    private void wb_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        Debug.Log("Downloading ... " + e.ProgressPercentage);
    }

    private void Unzip()
    {
        if (!android)
        {
            ZipUtil.Unzip(Application.dataPath + "/Packages/package.zip", Application.dataPath + "/Resources/");
            Debug.Log("Unzip @UnityEditor");
            //File.Delete(Application.dataPath + "/Resources/package.zip");
        }

        if (android)
        {
            ZipUtil.Unzip(Application.persistentDataPath + "/Packages/package.zip", Application.persistentDataPath + "/Resources/");
            Debug.Log("Unzip @UnityAndroid");
            //File.Delete(Application.persistentDataPath + "/Resources/package.zip");
        }
    }

    private void Update()
    {
        if (unZip)
        {
            unZip = false;
            Unzip();
        }
    }
    */
}