using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AuxiliarSonidos : MonoBehaviour
{

    public SoundManager soundManager;
    public SoundtrackManager soundtrackManager;

    public AudioSource Altavoz1;
    public AudioSource Altavoz2;
    public AudioSource AltavozSoundtrack;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundtrackManager = FindObjectOfType<SoundtrackManager>();
        PlayerPrefs.SetInt("SteelWoolAlreadyPlayed", 0);
    }

    private void AltavozSuena(AudioClip audioClip)
    {
        if (audioClip)
        {
            AudioSource audioSource = !Altavoz1.isPlaying ? Altavoz1 : Altavoz2;
            audioSource.volume = 1f;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public void llamarTlF1()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Tlf1));
    }

    public void llamarTlF2()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Tlf2));
    }

    public void llamarTlF3()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Tlf3));
    }

    public void llamarTlF4()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Tlf4));
    }

    public void llamarTlF5()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Tlf5));
    }

    public void llamarTlF6()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Tlf6));
    }

    public void sofaLevantarse()
    {
        AltavozSuena(soundManager.sonidoLevantarseSofa);
    }

    public void abrirPuertaPrin()
    {
        AltavozSuena(soundManager.sonidoPuertaAbrir[Random.Range(0, 2)]);
    }

    public void cerrarPuertaPrin()
    {
        AltavozSuena(soundManager.sonidoPuertaCerrar[Random.Range(0, 2)]);
        Invoke("RestorePitch", 2);
    }

    public void sonidoAbrirCortina()
    {
        AltavozSuena(soundManager.sonidoCortinaAbrir);
    }
    public void sonidoCerradaCortina()
    {
        AltavozSuena(soundManager.sonidoCortinaCerrar);
    }

    public void vozHola()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Hola));
    }

    public void vozHayAlguien()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.HayAlguien));
    }

    public void vozBromas()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Bromas));
        AltavozSoundtrack.GetComponent<AuxiliarSonidos>().FadeOut();
        Invoke("vozMaryAcostada", 4);
    }


    public void vozMaryAcostada()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MaryAcostada));
       
        GetComponent<AuxiliarSonidos>().ostEscena2Tema3();
        //FindObjectOfType<GameManager>().objetoSoundtrack.GetComponent<AudioSource>().volume = 0.3f; 
        Invoke("John_FinishInTheOffice", 5f);
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "Mary’s probably asleep already. ", false);
                break;
            case LanguageManager.Language.Spanish:
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "", false);
                break;
        }
    }

    public void vozHolaMary()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.HolaMary));
    }

    public void vozPeroQue()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.PeroQue));
        //AltavozSoundtrack.clip = soundtrackManager.Lucidez;
        //AltavozSoundtrack.Play();
        gameObject.GetComponent<AudioSource>().Play();

    }

    public void vozMaryAhi()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MaryAhi));
    }

    public void vozMaryAhi1()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MaryAhi1));
    }

    public void vozMaryAhi2()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MaryAhi2));
    }

    public void vozMaryAhi3()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MaryAhi3));
    }

    public void vozMaryAhi4()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MaryAhi4));
    }

    public void vozAhoraQue()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.AhoraQue));
    }

    public void vozHolaQuienEs()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.HolaQuienEs));
    }

    public void vozMary()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.Mary));
        FindObjectOfType<GameManager>().DevolverControl();
        //AltavozSoundtrack.clip = soundtrackManager.Tension;
        //AltavozSoundtrack.Play();
        Invoke("FadeOut", 34f);
    }
    public void vozNoPuedeEstar()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.NoPuedeEstar));
    }
    public void vozSusCosas()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.SusCosas));
    }

    public void vozPeroQueCo()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.PeroQueCo));
  
    }

    public void alboroto()
    {
        AltavozSuena(soundManager.alboroto);
        FindObjectOfType<GameManager>().habitacionDestrozadaMostrada = true;
        Invoke("vozPeroQueCo", 1.2f);
    }

    public void vozNoRecuerdo()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.NoRecuerdo));
    }

    public void vozDemasiadoAsustado()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.DemasiadoAsustado));
    }
    public void callBromas()
    {
        Invoke("vozMaryBroma", 2.5f);
    }
    public void vozMaryBroma()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MaryBroma));
    }

    public void cassetteTrabajo()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.CassetteTrabajo));
    }

    public void voztelefonoMary()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.TelefonoMary));
    }

    public void cassettePelea()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.CassettePelea));
    }

    public void vozNoPuedoSerYo()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.NoPuedoSerYo));
    }

    public void sonidoDialTv()
    {
        AltavozSuena(soundManager.sonidoDialTv);
    }

    public void sonidoKnock()
    {
        AltavozSuena(soundManager.sonidoKnock);
    }

    public void sonidoPuertaChirrido()
    {
        AltavozSuena(soundManager.sonidoPuertaChirrido);
        ostEscena4Tema7();
        Invoke("FadeIn", 7);
    }

    public void sonidoPuertaExitOpen()
    {
        AltavozSuena(soundManager.sonidoPuertaExitOpen);
    }

    public void sonidoPuertaExitClose()
    {
        AltavozSuena(soundManager.sonidoPuertaExitClose);
    }

    public void sonidoPuertaLock()
    {
        AltavozSuena(soundManager.sonidoPuertaLock);
    }

    public void sonidoPuertaUnlock()
    {
        AltavozSuena(soundManager.sonidoPuertaUnlock);
    }

    public void vozJohnSofa()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.JohnSofa));
    }

    public void vozJohnLuz()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.JohnLuz));
    }

    public void vozJohnNoEntiendo()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.JohnNoEntiendo));
    }
    public void vozMinutoFinal()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MinutoFinal));
    }
    public void vozCassette_Madness()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.cassette_Madness));
    }

    public void vozCassetteRuidos()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.CassetteRuidos));
    }

    public void vozJohn_Chord()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_Chord));
    }

    public void vozJohn_FinishInTheOffice()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_FinishInTheOffice));
        switch (FindObjectOfType<LanguageManager>().currentLanguage)
        {
            case LanguageManager.Language.English:
                FindObjectOfType<managersubtitulos>().escribirDurante(7, "Might as well finish in the office while I have my peace and quiet.", false);
                break;
            case LanguageManager.Language.Spanish:
                FindObjectOfType<managersubtitulos>().escribirDurante(3, "", false);
                break;
        }
    }
    public void FadeInRemote(AudioSource audioSource, float FadeTime)
    {
        StartCoroutine(FadeIn(audioSource, FadeTime));
    }

    public void FadeOuRemote(AudioSource audioSource, float FadeTime)
    {
        StartCoroutine(FadeOut(audioSource, FadeTime));
    }
    public void callJohnCor()
    {
        // Invoke("vozJohn_CorKnew", 4);
        if (PlayerPrefs.GetInt("SteelWoolAlreadyPlayed") != 1)
        {
            PlayerPrefs.SetInt("SteelWoolAlreadyPlayed", 1);
            Invoke("vozJohn_SteelWool", FindObjectOfType<Grabadora>().GetComponent<AudioSource>().clip.length);
        }
     
    }
    public void VozWhatTheHell()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.JohnWhatTheHell));
    }
    public void vozJohn_CorKnew()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_CorKnew));
    }

    public void vozJohn_SteelWool()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_SteelWool));
    }

    public void vozJohn_FridayAlready()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_FridayAlready));
    }

    public void vozJohn_enough()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_enough));
    }

    public void vozJohn_QuitMyJob()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_QuitMyJob));
    }

    public void vozJohn_Jewelry()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_Jewelry));
    }

    public void vozJohn_MaryDoThis()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.John_MaryDoThis));
    }



    public void sonidoTapaWC()
    {
        AltavozSuena(soundManager.sonidoTapaWC);
    }

    public void sonidoMinutoFinal()
    {
        AltavozSuena(soundManager.GetAudioClip(SoundManager.AudioName.MinutoFinal));
    }

    public void sonidoWaterPipe()
    {
        AltavozSuena(soundManager.sonidoWaterPipe);
    }

    public void sonidoLlenarBath()
    {
        AltavozSuena(soundManager.sonidoLlenarBath);
    }

    public void sonidoRecogerPapel()
    {
        AltavozSuena(soundManager.sonidoRecogerPapel);
    }

    public void sonidoRecogerDiario()
    {
        AltavozSuena(soundManager.sonidoRecogerDiario);
    }

    public void sonidoRecoger()
    {
        AltavozSuena(soundManager.sonidoRecoger);
    }

    public void sonidoCajonAbrir()
    {
        AltavozSuena(soundManager.sonidoCajonAbrir);
    }

    public void sonidoCajonCerrar()
    {
        AltavozSuena(soundManager.sonidoCajonCerrar);
    }

    public void sonidoLinternaOn()
    {
        AltavozSuena(soundManager.sonidoLinternaOn);
    }

    public void sonidoLinternaOff()
    {
        AltavozSuena(soundManager.sonidoLinternaOff);
    }

    public void sonidoEquiparInv()
    {
        AltavozSuena(soundManager.sonidoEquiparInv);
    }

    public void PararAltavoces()
    {
        Altavoz1.Stop();
        Altavoz2.Stop();
    }

    private void SuenaOst(AudioClip audioClip)
    {
        Debug.Log("Llamamos " + audioClip.name);
        AltavozSoundtrack.volume = 0.55f;
        gameObject.GetComponent<AudioSource>().clip = audioClip;
        gameObject.GetComponent<AudioSource>().Play();
    }

    //public void ostHabitacion405()
    //{
    //    SuenaOst(soundtrackManager.Habitacion405);
    //}
    public void ostTeaser()
    {
        SuenaOst(soundtrackManager.Teaser);
    }
    //public void ostSueñoEstatico5()
    //{
    //    SuenaOst(soundtrackManager.SuenoEstatico);
    //}

    //public void ostLucidez()
    //{
    //    SuenaOst(soundtrackManager.Lucidez);
    //}

    //public void ostKnock()
    //{
    //    SuenaOst(soundtrackManager.Knock);
    //}
    //public void ostPrisa()
    //{
    //    SuenaOst(soundtrackManager.Prisa);
    //}

    //public void ostTension()
    //{
    //    SuenaOst(soundtrackManager.Tension);
    //}

    //public void ostLlamada()
    //{
    //    SuenaOst(soundtrackManager.Llamada);
    //}

    //public void ostPerdida()
    //{
    //    SuenaOst(soundtrackManager.Perdida);
    //}

    //public void ostSubconsciente()
    //{
    //    SuenaOst(soundtrackManager.Subconsciente);
    //}

    //public void ostExposicion()
    //{
    //    SuenaOst(soundtrackManager.Exposicion);
    //}

    public void ostRealizacion()
    {
        //SuenaOst(soundtrackManager.Realizacion);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeIn(AltavozSoundtrack.GetComponent<AudioSource>(), 4f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOut(AltavozSoundtrack.GetComponent<AudioSource>(), 2f));
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = 0.3f;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.volume = 0f;
        audioSource.Play();
        while (audioSource.volume < 0.35f)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void TurnOnSpecialLight()
    {
        //GameObject.Find("Special Light").GetComponent<Light>().enabled = true;
    }
    public void TurnOffSpecialLight()
    {
        //GameObject.Find("Special Light").GetComponent<Light>().enabled = false;
    }
    public void ostEscena1Tema1()
    {
        SuenaOst(soundtrackManager.Escena1Tema1);
    }

    public void ostEscena2Tema3()
    {
        SuenaOst(soundtrackManager.Escena2Tema3);
    }

    public void ostEscena3Tema5()
    {
        SuenaOst(soundtrackManager.Escena3Tema5);
    }

    public void ostEscena3Tema5_variant()
    {
        SuenaOst(soundtrackManager.Escena3Tema5_variant);
    }
    public void ostEscena4Tema7()
    {
        SuenaOst(soundtrackManager.Escena4Tema7);
    }

    public void ostEscena5Tema6_2()
    {
        SuenaOst(soundtrackManager.Escena5Tema6_2);
    }

    public void ostEscena5Tema6_2_variant()
    {
        SuenaOst(soundtrackManager.Escena5Tema6_2_variant);
    }

    public void ostEscena5Tema6_2_variant_melody()
    {
        SuenaOst(soundtrackManager.Escena5Tema6_2_variant_melody);
    }

    public void ostEscena6Tema4_2()
    {
        SuenaOst(soundtrackManager.Escena6Tema4_2);
    }

    public void ostEscena6Tema4_2_variant()
    {
        SuenaOst(soundtrackManager.Escena6Tema4_2_variant);
    }

    public void ostEscena7Tema8_2()
    {
        SuenaOst(soundtrackManager.Escena7Tema8_2);
    }
    public void ostEscena8Tema9()
    {
        SuenaOst(soundtrackManager.Escena8Tema9);
    }
    public void ostEscena9Tema2()
    {
        SuenaOst(soundtrackManager.Escena9Tema2);
    }

}