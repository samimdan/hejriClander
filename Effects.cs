#region

using System.Numerics;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Media;
using Windows.Media.Playback;
using System;
using System.Diagnostics;
using Windows.Media.Core;

#endregion

namespace sysinfo;
public sealed partial class MainWindow : Window
{
 public  enum SoundType
 {
  Azan,
 Hour
 }
 private MediaPlayer _mediaPlayer=new MediaPlayer();

 private void PlaySound(SoundType soundType)
 {
  Debug.WriteLine("playSound");
  string soundFilePath = soundType == SoundType.Azan ? "ms-appx:///Assets/Waves/Azan.wav" : "ms-appx:///Assets/Waves/Hour.mp3";
  Uri soundUri = new Uri(soundFilePath);
  try { 
  _mediaPlayer.Source = MediaSource.CreateFromUri(soundUri);
  _mediaPlayer.Play();
 }
  catch (Exception ex)
  {
   Debug.WriteLine($"Error playing sound: {ex.Message}");
  }
 }
}

