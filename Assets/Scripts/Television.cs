using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class Television : MonoBehaviour
{
    private static Television _instance;
    public static Television Instance
    {
        get
        {
            return _instance;
        }
    }
    private bool isTurnedOn;

    private string code = "Television";

    public Material onMaterial;
    public Material offMaterial;

    public GameObject screen;

    private VideoPlayer videoPlayer;

    private UnityEvent<Television> onTurnedOnDo;

    private readonly Vector3 tvReceiverOffset = new Vector3(0f, -0.5f, 0.5f);
    private readonly Vector3 tvAttractOffset = new Vector3(1f, -0.5f, 1.5f);

    private bool _interactBefore = false;

    public Vector3 TvAttractPosition
    {
        get
        {
            return transform.position + tvAttractOffset;
        }
    }
    public Vector3 TVReciverPosition
    {
        get
        {
            return transform.position + tvReceiverOffset;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        isTurnedOn = false;
        videoPlayer = screen.GetComponent<VideoPlayer>();

        onTurnedOnDo = new UnityEvent<Television>();
        //onTurnedOnDo.AddListener(SetRoundInfo);
        //onTurnedOnDo.AddListener(TryAttractBoy);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeTvStatus()
    {
        isTurnedOn = !isTurnedOn;
        ChangeScreenStatus(isTurnedOn);
    }
    public bool GetTvStatus()
    {
        return isTurnedOn;
    }
    private void ChangeScreenStatus(bool isTurnedOn)
    {
        if (isTurnedOn)
        {
            screen.GetComponent<MeshRenderer>().material = onMaterial;
            videoPlayer.Play();

            if (_interactBefore)
            {
                return;
            }
            //SetRoundInfo(this);
            //TryAttractBoy(this);
            _interactBefore = true;
        }
        else
        {
            screen.GetComponent<MeshRenderer>().material = offMaterial;
            videoPlayer.Stop();
        }
    }
    public void WowMoment()
    {
        if (isTurnedOn)
        {
            screen.GetComponent<MeshRenderer>().material = offMaterial;
            videoPlayer.Stop();
        }
    }
    /*private void SetRoundInfo(Television tv)
    {

        StoryManager.Instance.SetCurrentRound(code);
    }
    private void TryAttractBoy(Television tv)
    {
        StartCoroutine(StoryManager.Instance.ReactToInteraction(tv.code, Toolkit.ProjectToXZ(tv.TvAttractPosition), tv.transform.position));
    }*/

}
