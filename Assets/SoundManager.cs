using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public LanguageManager languageManager;

    public AudioClip sonidoLevantarseSofa;

    public AudioClip sonidoRelojTicTac;
    public AudioClip sonidoRelojCampana;
    public AudioClip sonidoCortinaAbrir;
    public AudioClip sonidoCortinaCerrar;
    public AudioClip sonidoKnock;
    public AudioClip sonidoTapaWC;
    public AudioClip sonidoWaterPipe;
    public AudioClip sonidoLlenarBath;

    public AudioClip sonidoEquiparInv;
    public AudioClip sonidoGrabadoraRewind;
    public AudioClip sonidoGrabadoraSacar;
    public AudioClip sonidoGrabadoraMeter;
    public AudioClip sonidoGrabadoraBoton;
    public AudioClip sonidoRecogerDiario;
    public AudioClip alboroto;

    public AudioClip[] sonidoPuertaAbrir;
    public AudioClip[] sonidoPuertaCerrar;
    public AudioClip sonidoPuertaLocked;
    public AudioClip sonidoPuertaChirrido;
    public AudioClip sonidoPuertaExitOpen;
    public AudioClip sonidoPuertaExitClose;
    public AudioClip sonidoPuertaLock;
    public AudioClip sonidoPuertaUnlock;

    public AudioClip sonidoTelefonoDial;
    public AudioClip sonidoTelefonoPitido;
    public AudioClip[] sonidoTelefonoRing;
    public AudioClip sonidoTelefonoColgar;

    public AudioClip sonidoRecoger;
    public AudioClip sonidoCajonAbrir;
    public AudioClip sonidoCajonCerrar;
    public AudioClip sonidoLinternaOn;
    public AudioClip sonidoLinternaOff;

    public AudioClip sonidoRecogerPapel;

    public AudioClip sonidoDialTv; 

    public AudioSource audioSourcePlayer;

    public GameManager gManager;

    public AudioClip Placeholder;

    public enum AudioName
    {
        Hola,
        HayAlguien,
        Bromas,
        MaryAcostada,
        HolaMary,
        PeroQue,
        MaryAhi,
        MaryAhi1,
        MaryAhi2,
        MaryAhi3,
        MaryAhi4,
        AhoraQue,
        HolaQuienEs,
        Mary,
        NoPuedeEstar,
        SusCosas,
        PeroQueCo,
        NoRecuerdo,
        DemasiadoAsustado,
        MaryBroma,
        CassetteJohnEntre,
        NoPuedoSerYo,
        CassetteTrabajo,
        TelefonoMary,
        CassettePelea,
        Tlf1,
        Tlf2,
        Tlf3,
        Tlf4,
        Tlf5,
        Tlf6,
        JohnSofa,
        JohnLuz,
        JohnNoEntiendo,
        MinutoFinal,
        cassette_Madness,
        CassetteRuidos,
        John_Chord, //
        John_FinishInTheOffice,//
        John_CorKnew, //
        John_SteelWool,//
        John_FridayAlready,//
        John_enough,
        John_QuitMyJob,
        John_Jewelry,
        John_MaryDoThis,
        JohnWhatTheHell



    }

    public AudioClip GetAudioClip(AudioName audioName)
    {
        AudioClip clip = null;
        string localizedName = GetLocalizedName(audioName);
        if (localizedName != "")
        {
            clip = Resources.Load<AudioClip>(localizedName);
        }
        if (clip == null)
        {
            clip = Placeholder;
            print(localizedName + "not found");
        }
        return clip;
    }

    public string GetLocalizedName(AudioName audioName)
    {
        return LocalizeMP3(audioName.ToString());
    }

    private string LocalizeMP3(string name)
    {
        return "Doblaje/" + name + "_" + languageManager.GetLanguageChars();
    }
}
