using System;
using System.Collections.Generic;
using UnityEngine;

namespace Parana.Common.Sytems
{
    public static class CommandSystem
    {
        private static Stack<Action> _actions = new();
        
        public static void AddAction(string identifier, string data)
        {
            if (string.IsNullOrEmpty(data)) return;
            _actions.Push(() => Directive(identifier, data));
        }
        
        public static void FireAction()
        {
            if (_actions.Count == 0) return;
            _actions.Pop().Invoke();
        }
        
        private static void Directive(string identifier, string data)
        {
            // PushDirective<EmptyDirectiveContent> pushDirective;
            try
            {
                // pushDirective = JsonConvert.DeserializeObject<PushDirective<EmptyDirectiveContent>>(data);
            }
            catch (Exception e)
            {
                Debug.Log($"Fail to deserialize PN data, directive canceled, reason: {e}");
                return;
            }
            
            // if (NavigationSystem.AppState != AppState.IDLE) return;
        
            // AddDirectiveByType(pushDirective, data);
        }
        //
        // private static void AddDirectiveByType(PushDirective<EmptyDirectiveContent> pushDirective, string data)
        // {
        //     // if (pushDirective.Type == DirectiveType.TournamentConcluded)
        //     //     ShowTournamentResults(data);
        //     //
        //     // if (pushDirective.Type == DirectiveType.DailyGift) 
        //     //     ShowGiftTab();
        // }

        private static void ShowGiftTab()
        {
            // NavigationSystem.GoToGiftsTab();
        }

        private static void ShowTournamentResults(string data)
        {
            // var TournamentConcludedData = new PushDirective<TournamentConcludedContent>();
            // try
            // {
            //     TournamentConcludedData = JsonConvert.DeserializeObject<PushDirective<TournamentConcludedContent>>(data);
            // }
            // catch (Exception e)
            // {
            //     Debug.Log($"Fail to deserialize PN data, directive canceled, reason: {e}");
            //     return;
            // }
            //
            // if (string.IsNullOrEmpty(TournamentConcludedData.Content.TournamentID)) return;
            //
            // NavigationSystem.GoToTournamentTab();
            // Lookup.Instance.CommonEvents.OnTournamentDetailsRequestedAction.Invoke(TournamentConcludedData.Content.TournamentID);
        }
    }
}